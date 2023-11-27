using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmniyetPRojesi.Models;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace EmniyetPRojesi.Controllers
{
    public class IceriksController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Iceriks
        public ActionResult Index()
        {
            var icerik = db.Icerik.Include(i => i.Birimler).Include(i => i.Tur).Include(i => i.Yonetici);
            return View(icerik.ToList());
        }

        // GET: Iceriks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);
        }

        // GET: Iceriks/Create
        public ActionResult Create()
        {
            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi");
            ViewBag.TurID = new SelectList(db.Tur, "TurID", "TurAdi");
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "TC");
            return View();
        }

        // POST: Iceriks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IcerikID,Path,BirimID,QR,TurID,URL,YoneticiID")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                db.Icerik.Add(icerik);
                db.SaveChanges();
                string link = $"{this.Request.Url.Scheme}://{this.Request.Url.Host}:{this.Request.Url.Port}" + "/Home/Icerik/" + icerik.IcerikID;
                icerik.URL = link;
                Url generator = new Url(link);
                string payload = generator.ToString();

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                var qrCodeAsBitmap = qrCode.GetGraphic(20);

                string path = Path.Combine(Server.MapPath("~/Files/QRCodes"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string dosyadi = "qrcode_" + DateTime.Now.Ticks;
                string filePath = Path.Combine(Server.MapPath("~/Files/QRCodes/"+ dosyadi+ ".png"));
                qrCodeAsBitmap.Save(filePath);
                string fileName = Path.GetFileName(filePath);
         

                string imageUrl =  "/Files/QRCodes/" + fileName;
                icerik.QR = imageUrl;
                db.Entry(icerik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi", icerik.BirimID);
            ViewBag.TurID = new SelectList(db.Tur, "TurID", "TurAdi", icerik.TurID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "TC", icerik.YoneticiID);
            return View(icerik);
        }

        // GET: Iceriks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi", icerik.BirimID);
            ViewBag.TurID = new SelectList(db.Tur, "TurID", "TurAdi", icerik.TurID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "TC", icerik.YoneticiID);
            return View(icerik);
        }

        // POST: Iceriks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IcerikID,Path,BirimID,QR,TurID,URL,YoneticiID")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icerik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi", icerik.BirimID);
            ViewBag.TurID = new SelectList(db.Tur, "TurID", "TurAdi", icerik.TurID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "TC", icerik.YoneticiID);
            return View(icerik);
        }

        // GET: Iceriks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);
        }

        // POST: Iceriks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Icerik icerik = db.Icerik.Find(id);
            db.Icerik.Remove(icerik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
