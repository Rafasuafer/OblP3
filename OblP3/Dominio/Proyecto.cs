using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;






namespace Dominio
{
    public class Proyecto
    {
        private int id;
        private string titulo;
        private string descripcion;
        private decimal montoSolicitado;
        private int cantidadCuotas;
        private DateTime fecha;
        private Resolucion resolucion;
        private Usuario usuario;
        private int tasa;
        public string NombreArchivoPortada { get; set; }
        public HttpPostedFileBase Archivo { get; set; }


        public static List<Proyecto> listaPendiente;


        public static ICollection<Proyecto> MisProyectos { get; private set; }
            = new List<Proyecto>();

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal MontoSolicitado
        {
            get { return montoSolicitado; }
            set { montoSolicitado = value; }
        }
        public int CantidadCuotas
        {
            get { return cantidadCuotas; }
            set { cantidadCuotas = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public int Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }
        public Resolucion Resolucion
        {
            get { return resolucion; }
            set { resolucion = value; }
        }
      


        public static string Validar(Proyecto unP)

        {

            string validacion = "#Error/es: ";

            if (unP.Descripcion.Length < 30)
            {
                validacion += "La descripcion debe tener al menos 30 caracteres |";
            }
            if (unP.Titulo.Length < 1)
            {
                validacion += "Debe ingresar titulo |";
            }
            if (unP.MontoSolicitado < 2000)
            {
                validacion += "El monto muy bajo |";
            }
            if (unP.CantidadCuotas < 10)
            {
                validacion += "Cantidad de cuotas invalida |";
            }
            
            if (validacion == "#Error/es: ")
            {
                validacion = "ok";
            }
            return validacion;
        }

        public virtual decimal CalcularMontoProyecto(Proyecto unP)
        {

            decimal monto = 0;

            return monto;
        }
        public decimal MontoPorCuota(Proyecto unP)
        {
            decimal monto = CalcularMontoProyecto(unP);
            decimal montoPorCuota = monto / unP.CantidadCuotas;
            return montoPorCuota;
        }
        public static bool ExisteProyectoC(Proyecto unP)
        {
            bool existe = false;
            List<Cooperativo> unCop = getPCByCi(unP.Usuario.Ci);
            int i = 0;
            while (!existe && unCop != null &&  i > unCop.Count)
            {
                if(unCop[i].resolucion.Estado == "Pendiente")
                {
                    existe = true;
                }
                i++;
            }return existe;
            
            }
        public static bool ExisteProyectoP(Proyecto unP)
        {
            bool existe = false;
            List<Personal> unPer = getPPByCi(unP.Usuario.Ci);
            int i = 0;
            while (!existe && unPer != null && i > unPer.Count)
            {
                if (unPer[i].resolucion.Estado == "Pendiente")
                {
                    existe = true;
                }
                i++;
            }
            return existe;

        }
        public bool SubirArchivoGuardarNombre()
        {
            if (this.Archivo != null)
            {
                if (guardarArchivo(Archivo))
                {
                    this.NombreArchivoPortada = Archivo.FileName;
                    return true;
                }
            }
            return false;
        }
        
        private bool guardarArchivo(HttpPostedFileBase archivo)
        {
            if (archivo != null)
            {
                string ruta =
               System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/fotos");
                if (!System.IO.Directory.Exists(ruta))
                    System.IO.Directory.CreateDirectory(ruta);
                ruta = System.IO.Path.Combine(ruta, archivo.FileName);
                archivo.SaveAs(ruta);
                return true;
            }
            else
                return false;
        }
    }
     

    }


