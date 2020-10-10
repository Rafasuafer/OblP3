using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proyecto
    {
        public int Id { get; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoSolicitado { get; set; }
        public int CantidadCuotas { get; set; }
        public DateTime Fecha { get; set; }
        public Resolucion Resolucion { get; set; }
        public Usuario Usuario { get; }

        
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
