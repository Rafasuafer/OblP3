using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario 
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public DateTime FechaNacimiento { get; }

        public ICollection<Cliente> MisClientes { get; private set; }
            = new List<Cliente>();

        public static bool AgregarCliente(Cliente unC)
        {
            if (unC == null
                || !Validar(unC)
                || MisUsuarios.Contains(unC))
                return false;
            MisUsuarios.Add(unC);
            return true;
        }
        public static bool Validar(Cliente unC)
        {
            bool esValido = false;
            if(unC.Nombre.ToString().Length > 3 && unC.Ci == 8 
                && unC.Email.ToString().Length >= 6 
                && unC.Password.ToString().Length >= 8 
                && (DateTime.Now.Year - unC.FechaNacimiento.Year) >= 21 
                && unC.Celular == 9)
            {
                esValido = true;
            }
            else
            {
                esValido = false;
            }
            return esValido;
        }
        
    }
}
