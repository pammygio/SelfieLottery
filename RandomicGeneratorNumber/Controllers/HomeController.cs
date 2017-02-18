using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstrazionePremi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Page = "Index";
            ViewBag.Title = "Grazie";
            ViewBag.SubTitle = "La community DotNetCode, vuole ringraziare tutti voi, per aver partecipato all'evento, regalando al più fortunato un premio.";
            return View();
        }

        public ActionResult Registrazione()
        {
            ViewBag.Page = "Registrazione";
            ViewBag.Title = "Registrazione";
            ViewBag.SubTitle = System.DateTime.Now.ToShortDateString();

            return View();
        }

        public ActionResult Estrazione()
        {
            ViewBag.Page = "Estrazione";
            ViewBag.Title = "Estrazione";
            ViewBag.SubTitle = System.DateTime.Now.ToShortDateString();

            return View();
        }

    }
}
