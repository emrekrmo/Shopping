using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisVerisMVCFluent.Controllers
{
    public class BasketController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Basket
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login","Account");

            var userid = (int)Session["UserId"];
            var liste = _uw.SepetManager.SepetGetir(userid);
            return View(liste);
        }

        public ActionResult Add(int productId)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            var userid = (int)Session["UserId"];
            _uw.SepetManager.UrunEkle(productId, userid, 1);
            _uw.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int productId)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            var userid = (int)Session["UserId"];
            _uw.SepetManager.UrunSil(productId, userid);
            _uw.Complete();
            return RedirectToAction("Index");
        }
    }
}