using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace WebAppObl.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AltaCliente()
        {
            
            return View(new Usuario());
        }
        [HttpPost]
        public ActionResult AltaCliente(Cliente unC)
        {
            

            string msg = "";

            if (Cliente.AgregarCliente(unC) 
                && unC.Nombre.ToString().Length > 3 && unC.Ci == 8 
                && unC.Email.ToString().Length >=6 && unC.Password.ToString().Length >= 8 
                && (DateTime.Now.Year - unC.FechaNacimiento.Year) >= 21 
                && unC.Celular == 9)
            {
                msg = "El voluntario fue dado de alta exitosamente";
                return RedirectToAction("Index", new { mensaje = msg });

            }
            else
            {
                msg = "Hubo un error, intente nuevamente";
            }

            ViewBag.mensaje = msg;

            return View(unC);
        }

    }
}