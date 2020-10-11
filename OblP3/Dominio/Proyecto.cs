using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proyecto
    {
        private int id { get; }
        private string titulo { get; set; }
        private string descripcion { get; set; }
        private decimal montoSolicitado { get; set; }
        private int cantidadCuotas { get; set; }
        private DateTime fecha { get; set; }
        private Resolucion resolucion { get; set; }
        private Usuario usuario { get; }


        public int Id
        {
            get { return id; }
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


        public void PresentarProyecto(Proyecto unP)
        {

            if (ValidarPendiente(unP) == "ok")
            {
                if (ValidarRequisitos(unP) == "ok"){
                    decimal monto = calcularMonto(unP);
                }
            }
           
        }
        public string ValidarPendiente(Proyecto unP)
        {
            string msg = "ok";
            int i = 0;
            bool existe = false;
            while (i > Repositorios.RepositorioProyecto.Proyectos && !existe)
            {
                if (unP.Usuario.Ci == Session["ci"])
                {
                    existe = true;
                    bool pendiente = false;
                    if (unP.Resolucion.Estado == "pendiente" && !pendiente)
                    {
                        pendiente = true;
                        msg = "#Ya cuenta con un proyecto pendiente de aceptacion";
                    }

                }
                i++;
            }

            return msg;
        }
        public string ValidarRequisitos(Proyecto unP)
        {
            string msg = "ok";
            return msg;
        }
        public decimal calcularMonto(Proyecto unP)
        {


        }
        public bool Validar()
        {
            return Id > 0 &&
                !string.IsNullOrEmpty(Titulo)
                && !string.IsNullOrEmpty(Descripcion);
        }
    }
    
}
