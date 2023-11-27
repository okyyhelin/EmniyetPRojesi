using EmniyetPRojesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmniyetPRojesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Icerik(int id)
        {
            if(id != null)
            {
                Entities1 db = new Entities1();
                var icerik = db.Icerik.Find(id);
                if(icerik != null)
                {
                    Rapor rapor = new Rapor();
                    rapor.IcerikID = icerik.IcerikID;
                    rapor.Tarih = DateTime.Now;
                    db.Rapor.Add(rapor);
                    db.SaveChanges();

                    return Redirect(icerik.Path);
                }
            }
            return RedirectToAction("Index");
        }

    }
}