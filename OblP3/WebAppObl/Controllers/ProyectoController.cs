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
        public ActionResult Index(string mensaje)
        {
            return View(mensaje);
        }

        [HttpGet]
        public ActionResult AltaPersonal()
        {
            return View(new Personal());

        }
        [HttpPost]
        public ActionResult AltaPersonal(Personal unP)
        {
            int ci = (int)(Session["ci"]);
            Usuario unU = Usuario.getUsuarioByCi(ci);
            string msg = "";
            if (unP.Descripcion.Length >= 30 && unP.Titulo.Length >= 1 && unP.MontoSolicitado > 2000 && unP.CantidadCuotas > 0 && unP != null && unP.Explicacion.Length >= 10 && Personal.AltaPersonal(unP, unU) == "ok") {

                    msg = "Alta exitosa";
                    return RedirectToAction("Index", new { mensaje = msg });
                }
                else
                {
                msg = Personal.AltaPersonal(unP, unU);


                }

     
            ViewBag.mensaje = msg;
            return View(unP);

        }

        [HttpGet]
        public ActionResult AltaCooperativo()
        {
            return View(new Cooperativo());

        }
        [HttpPost]
        public ActionResult AltaCooperativo(Cooperativo unP)
        {
            int ci = (int)(Session["ci"]);
            Usuario unU = Usuario.getUsuarioByCi(ci);
            string msg = "";
            if (unP.Descripcion.Length >= 30 && unP.Titulo.Length >= 1 && unP.MontoSolicitado > 0 && unP.CantidadCuotas > 0 && unP != null && unP.Ingtegrantes > 1 && Cooperativo.AltaCooperativo(unP, unU) == "ok")
            {

                msg = "Alta exitosa";
                return RedirectToAction("Index", new { mensaje = msg });
            }
            else
            {
                msg = "#Error: Intente nuevamente";


            }


            ViewBag.mensaje = msg;
            return View(unP);

        }

    }
}