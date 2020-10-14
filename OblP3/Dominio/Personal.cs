using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Personal : Proyecto
    {
        private string explicacion { get; set; }

        public string Explicacion
        {
            get { return explicacion; }
            set { explicacion = value; }
        }
        public static string AltaPersonal(Proyecto unP, Usuario unU, string explicacion)
        {

            string msg = "";

            if (!ExisteProyectoP(unP) && !ExisteProyectoC(unP))
            {
                if (Proyecto.Validar(unP) == "ok")
                {
                    Personal p = (Personal)unP;
                    p.Usuario = unU;
                    p.Tasa = getTasaByCuota(unP.CantidadCuotas);
                    p.Explicacion = explicacion;
                    listaPendiente.Add(p);
                    msg += "ok";
                }
                else
                {
                    msg += Proyecto.Validar(unP);
                }

            }
            else
            {
                msg += "Ya existe un proyecto pendiente de aprobacion";
            }

            return msg;
        }


        public override decimal CalcularMontoProyecto(Proyecto unP)
        {

            int cantidadCuotas = unP.CantidadCuotas;
            int tasa = getTasaByCuota(unP.CantidadCuotas);

            decimal monto = 0;
            decimal montoMaximo = getMaxMonto();

            if (monto >= montoMaximo)
            {

                monto = montoMaximo - (montoMaximo * 20) / 1000;

            }
            else
            {
                monto = unP.MontoSolicitado;

            }
            return monto;
        }

    }

}

    



