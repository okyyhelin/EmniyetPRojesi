using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmniyetPRojesi.Models;

namespace EmniyetPRojesi.Controllers
{
    [Authorize]
    public class BirimYoneticisController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: BirimYoneticis
        public ActionResult Index()
        {
            var birimYonetici = db.BirimYonetici.Include(b => b.Birimler);
            return View(birimYonetici.ToList());
        }

        // GET: BirimYoneticis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirimYonetici birimYonetici = db.BirimYonetici.Find(id);
            if (birimYonetici == null)
            {
                return HttpNotFound();
            }
            return View(birimYonetici);
        }

        // GET: BirimYoneticis/Create
        public ActionResult Create()
        {
            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi");
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "AdSoyad");
            return View();
        }

        // POST: BirimYoneticis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BirimYoneticiID,BirimID,YoneticiID")] BirimYonetici birimYonetici)
        {
            if (ModelState.IsValid)
            {
                db.BirimYonetici.Add(birimYonetici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi", birimYonetici.BirimID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "AdSoyad", birimYonetici.YoneticiID);
            return View(birimYonetici);
        }

        // GET: BirimYoneticis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirimYonetici birimYonetici = db.BirimYonetici.Find(id);
            if (birimYonetici == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi", birimYonetici.BirimID);
            return View(birimYonetici);
        }

        // POST: BirimYoneticis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirimYoneticiID,BirimID,YoneticiID")] BirimYonetici birimYonetici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birimYonetici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirimID = new SelectList(db.Birimler, "BirimID", "BirimAdi", birimYonetici.BirimID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiId", "AdSoyad", birimYonetici.YoneticiID);

            return View(birimYonetici);
        }

        // GET: BirimYoneticis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirimYonetici birimYonetici = db.BirimYonetici.Find(id);
            if (birimYonetici == null)
            {
                return HttpNotFound();
            }
            return View(birimYonetici);
        }

        // POST: BirimYoneticis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BirimYonetici birimYonetici = db.BirimYonetici.Find(id);
            db.BirimYonetici.Remove(birimYonetici);
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
