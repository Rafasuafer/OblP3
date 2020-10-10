using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace WebAppObl.Controllers
{
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AltaProyecto()
        {
            return View(new Proyecto());

        }
        [HttpPost]
        public ActionResult AltaProyecto(Proyecto unP)
        {
            if (unP.Descripcion.Length >= 30) { }
            return View();

        }
        
    }
}