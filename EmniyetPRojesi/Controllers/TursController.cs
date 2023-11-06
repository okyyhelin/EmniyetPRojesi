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
    public class TursController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Turs
        public ActionResult Index()
        {
            return View(db.Tur.ToList());
        }

        // GET: Turs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Tur.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // GET: Turs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TurID,TurAdi")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                db.Tur.Add(tur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tur);
        }

        // GET: Turs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Tur.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // POST: Turs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TurID,TurAdi")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tur);
        }

        // GET: Turs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Tur.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // POST: Turs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tur tur = db.Tur.Find(id);
            db.Tur.Remove(tur);
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
