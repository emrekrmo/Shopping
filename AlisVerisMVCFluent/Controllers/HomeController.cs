using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisVerisMVCFluent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Urun> liste;
            using (UnitOfWork uw = new UnitOfWork())
            {
                liste = uw.UrunRep.Listele();
            }

            return View(liste);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}