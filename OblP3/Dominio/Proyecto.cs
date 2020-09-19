using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Proyecto
    {
        public int Id { get; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoSolicitado { get; set; }
        public int CantidadCuotas { get; set; }
        public DateTime Fecha { get; set; }
        public Resolucion Resolucion { get; set; }

        static void Main(string[] args)
        {
        }
    }
}
