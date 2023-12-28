using EmniyetPRojesi.Models;
using EmniyetPRojesi.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmniyetPRojesi.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password, string returnUrl)
        {
            Entities1 db = new Entities1();
            var sifre = UygulamaHelper.CreateMD5(password);
            var kullanici = db.Yonetici.Where(x => x.KullaniciAdi == username && x.Sifre == sifre).FirstOrDefault();

            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, false);
                if(returnUrl != "")
                {
                    return Redirect(returnUrl);
                }
                else
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalıdır";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}