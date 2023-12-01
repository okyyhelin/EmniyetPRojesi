using EmniyetPRojesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmniyetPRojesi.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            Entities1 db = new Entities1();
            var kullanici = db.Yonetici.Where(x => x.KullaniciAdi == username).FirstOrDefault();

            if (username == "admin" && password == "1234")
            {
                HttpContext.Session.Add("Kullanici", kullanici);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalıdır";
                return View();
            }
        }
    }
}