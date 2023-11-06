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
    public class BirimlerController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Birimlers
        public ActionResult Index()
        {
            return View(db.Birimler.ToList());
        }

        // GET: Birimlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birimler birimler = db.Birimler.Find(id);
            if (birimler == null)
            {
                return HttpNotFound();
            }
            return View(birimler);
        }

        // GET: Birimlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birimlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BirimID,BirimAdi")] Birimler birimler)
        {
            if (ModelState.IsValid)
            {
                db.Birimler.Add(birimler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birimler);
        }

        // GET: Birimlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birimler birimler = db.Birimler.Find(id);
            if (birimler == null)
            {
                return HttpNotFound();
            }
            return View(birimler);
        }

        // POST: Birimlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirimID,BirimAdi")] Birimler birimler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birimler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birimler);
        }

        // GET: Birimlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birimler birimler = db.Birimler.Find(id);
            if (birimler == null)
            {
                return HttpNotFound();
            }
            return View(birimler);
        }

        // POST: Birimlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birimler birimler = db.Birimler.Find(id);
            db.Birimler.Remove(birimler);
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
