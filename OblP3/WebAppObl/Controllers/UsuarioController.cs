using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;



namespace WebAppObl.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(int ci, string password)
        {
            Usuario usuario = Usuario.getUsuarioByCi(ci);

            if (usuario == null)
            {
                ViewBag.mensaje = "Usuario o contraseña incorrectos";
                return View();
            }

            Session["rol"] = usuario.Rol;
            Session["nombre"] = usuario.Nombre;
            return Redirect("/Producto/Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }
    }
}