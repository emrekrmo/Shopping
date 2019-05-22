using BLL;
using BLL.Managers;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisVerisMVCFluent.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork _uw;

        public AccountController()
        {
            _uw = new UnitOfWork();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        public ActionResult SifreGonder(string email)
        {
            _uw.MusteriManager.SifreHatirlat(email);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string sifre)
        {
            Musteri kisi = _uw.MusteriManager.GirişYap(email, sifre);
            if (kisi == null)
            {
                ModelState.AddModelError("", "Giriş hatalı");
                return View();
            } else
            {
                Session["UserId"] = kisi.MusteriId;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Musteri m)
        {
            if (_uw.MusteriManager.Kayit(m))
            {
                var kisi = _uw.MusteriManager.GirişYap(m.Email, m.Sifre);
                Session["UserId"] = kisi.MusteriId;
                return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Kayıt Başarısız");
            return View(m);
        }

        ~AccountController()
        {
            _uw.Dispose();
        }
    }
}