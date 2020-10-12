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

        public static string AltaCooperativo(Cooperativo unP, Usuario unU)
        {
            string msg = "";

            if (getPCByCi(unP.Usuario.Ci) && getPPByCi(unP.Usuario.Ci))
            {
                if (Validar(unP) == "ok")
                {
                    unP.Usuario = unU;
                    unP.Tasa = getTasaByCuota(unP.CantidadCuotas);
                    MisProyectos.Add(unP);
                    msg += "ok";
                }
                else
                {
                    msg += Validar(unP);
                }

            }
            else
            {
                msg += "Ya existe un proyecto pendiente de aprobacion";
            }



            return msg;
        }
        public static string Validar(Cooperativo unP)

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
            if (unP.Integrantes < 2 )
            {
                validacion += "Deben ser al menos 2 integrantes |";
            }
            if (validacion == "#Error/es: ")
            {
                validacion = "ok";
            }
            return validacion;
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
