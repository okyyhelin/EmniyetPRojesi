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
    public class LoglarsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Loglars
        public ActionResult Index()
        {
            return View(db.Loglar.ToList());
        }

        // GET: Loglars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loglar loglar = db.Loglar.Find(id);
            if (loglar == null)
            {
                return HttpNotFound();
            }
            return View(loglar);
        }

        // GET: Loglars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loglars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogID,TabloAdi,DegisiklikTarihi,DegisiklikYapanKisi,IP,DegisiklikTuru,YoneticiID")] Loglar loglar)
        {
            if (ModelState.IsValid)
            {
                db.Loglar.Add(loglar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loglar);
        }

        // GET: Loglars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loglar loglar = db.Loglar.Find(id);
            if (loglar == null)
            {
                return HttpNotFound();
            }
            return View(loglar);
        }

        // POST: Loglars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LogID,TabloAdi,DegisiklikTarihi,DegisiklikYapanKisi,IP,DegisiklikTuru,YoneticiID")] Loglar loglar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loglar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loglar);
        }

        // GET: Loglars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loglar loglar = db.Loglar.Find(id);
            if (loglar == null)
            {
                return HttpNotFound();
            }
            return View(loglar);
        }

        // POST: Loglars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loglar loglar = db.Loglar.Find(id);
            db.Loglar.Remove(loglar);
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
