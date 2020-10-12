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
        public static string AltaPersonal(Personal unP, Usuario unU)
        {
            string msg = "";

            if(getPCByCi(unP.Usuario.Ci) && getPPByCi(unP.Usuario.Ci))
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
        public static string Validar(Personal unP) 

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
            if (unP.Explicacion.Length < 10 )
            {
                validacion += "La explicacion debe tener al menos 30 caracteres |";
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

    


}
