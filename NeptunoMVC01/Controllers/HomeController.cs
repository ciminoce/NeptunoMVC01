using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeptunoMVC01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Su pagina de descripción del proyecto.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Su página de Contacto.";
            ViewBag.Calle = "One Microsoft Way";
            ViewBag.Provincia = "Redmond, WA 98052-6399";
            ViewBag.Telefono = "425.555.0100";
            return View();
        }
    }
}