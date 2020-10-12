using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
        public bool Validar()
        {
            return Id > 0 &&
                !string.IsNullOrEmpty(Titulo)
                && !string.IsNullOrEmpty(Descripcion);
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
    }
    
}
