using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
            return View(new Proyecto());

        }
        [HttpPost]
        public ActionResult AltaPersonal(Proyecto unP, string explicacion)
        {
            int ci = (int)(Session["ci"]);
            Usuario unU = Usuario.getUsuarioByCi(ci);
            string msg = "";
            if (unP.Descripcion.Length >= 30 
                && unP.Titulo.Length >= 1 
                && unP.MontoSolicitado > 2000 && unP.CantidadCuotas > 0 
                && unP != null && explicacion.Length >= 10 
                && Personal.AltaPersonal(unP, unU, explicacion) == "ok") {

                    msg = "Alta exitosa";
                    return RedirectToAction("Index", new { mensaje = msg });
                }
                else
                {
                msg = Personal.AltaPersonal(unP, unU, explicacion);


                }

     
            ViewBag.mensaje = msg;
            return View(unP);

        }

        [HttpGet]
        public ActionResult AltaCooperativo()
        {
            return View(new Proyecto());

        }
        [HttpPost]
        public ActionResult AltaCooperativo(Proyecto unP, int integrantes)
        {
            int ci = (int)(Session["ci"]);
            Usuario unU = Usuario.getUsuarioByCi(ci);
            string msg = "";
            if (unP.Descripcion.Length >= 30 
                && unP.Titulo.Length >= 1 
                && unP.MontoSolicitado > 0 && unP.CantidadCuotas > 0 
                && unP != null && integrantes > 1 
                && Cooperativo.AltaCooperativo(unP, unU, integrantes) == "ok")
            {

                msg = "Alta exitosa";
                return RedirectToAction("MostrarProyecto");
            }
           else
                {
                    msg = Cooperativo.AltaCooperativo(unP, unU, integrantes);


                }


            ViewBag.mensaje = msg;
            return View(unP);

        }
        [HttpGet]
        public ActionResult MostrarProyecto()
        {
            int ci = (int)(Session["ci"]);
            List<Cooperativo> cooperativo = progetPCByCi(ci);
            List<Personal> personal = getPPByCi(ci);
           foreach(Cooperativo unC in cooperativo)
            {
                if(unC.Resolucion.Estado == "Pendiente")
                {
                    ViewBag.unCooperativo = unC;
                    Proyecto.MisProyectos.Add(unC);

                }
                else
                {
                    ViewBag.unCooperativo = null;
                }
            }
            foreach (Personal unP in personal)
            {
                if (unP.Resolucion.Estado == "Pendiente")
                {
                    ViewBag.unPersonal = unP;
                    Proyecto.MisProyectos.Add(unP);

                }
                else
                {
                    ViewBag.unPersonal = null;
                }
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult MostrarTodosMisProyectos()
        {
            int ci = (int)(Session["ci"]);
            List<Cooperativo> cooperativo = progetPCByCi(ci);
            ViewBag.Cop = cooperativo;
           List<Personal> personal = getPPByCi(ci);
            ViewBag.Per = personal;
            return View();
        }
        [HttpGet]
        public ActionResult MostrarTodosLosProyectos()
        {
            List<Cooperativo> cooperativos = getPC();
            ViewBag.Cop = cooperativos;
            List<Personal> personales = getPP();
            ViewBag.Per = personales;
            return View();
        }
        

        [HttpGet]
        public ActionResult ConfirmarEstado(int id)
        {
            if (Session["rol"] == null)
            {
                return Redirect("/usuario/login");
            }
            if (Session["rol"].ToString() != "admin")
            {
                return Redirect("Index");
            }
            Proyecto proyecto = getProyectooById(id);

            return View(proyecto);
        }



        [HttpPost]
        public ActionResult ConfirmarEstado(Proyecto unP, int id)
        {
            string msg = "";
            if (sistema.ModificarProducto(id, producto) == "ok" && producto.Peso > 0 && producto.Precio > 0)
            {
                msg = "Modificacion exitosa";
                RedirectToAction("Index", new { mensaje = msg });
            }
            else
            {
                msg = sistema.ModificarProducto(id, producto);

            }
            ViewBag.mensaje = msg;

            return View(producto);
        }
    }
}