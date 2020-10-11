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


            if (Validar(unP) == "ok")
            {
                /*unP.Id = GestorId.GenDonId;
                nDonacion.Voluntario = vol;
                donaciones.Add(nDonacion);*/
                msg += "ok";
            }
            else
            {
                msg += Validar(unP);
            }


            return msg;
        }
        public string Validar(Personal unP) 

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

    }

}

    


}
