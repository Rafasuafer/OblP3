using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cooperativo : Proyecto
    {
        private int integrantes;



        public int Integrantes
        {
            get { return integrantes; }
            set { integrantes = value; }
        }
        
        public static string AltaCooperativo(Proyecto unP, Usuario unU, int integrantes)
        {

            string msg = "";
            
            if (!ExisteProyectoP(unP) && !ExisteProyectoC(unP))
            {
                if (Proyecto.Validar(unP) == "ok")
                {
                    Cooperativo c = (Cooperativo)unP;
                    c.Usuario = unU;
                    c.Tasa = getTasaByCuota(unP.CantidadCuotas);
                    c.Integrantes = integrantes;
                    listaPendiente.Add(c);
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
            Cooperativo c = (Cooperativo)unP;
            decimal montoMaximo = getMaxMonto();
            decimal cantidadIntegrantes = Decimal.ToInt32(c.Integrantes);
            if (monto >= montoMaximo)
            {
                if (cantidadIntegrantes >= 10)
                {
                    monto = montoMaximo + (montoMaximo * 20) / 100;

                }
                else
                {
                    monto = unP.MontoSolicitado + ((cantidadIntegrantes * 2) * 100) / montoMaximo;

                }

            }
            else
            {

                monto = unP.MontoSolicitado;
            }
            return monto;

        }

    }
}
