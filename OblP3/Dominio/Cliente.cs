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
        public DateTime FechaNacimiento { get; }
        public ICollection<Cliente> MisClientes { get; set; }


        public bool AgregarCliente(Cliente unC)
        {
            if (unC == null
                || !unC.Validar()
                || MisClientes.Contains(unC))
                return false;
            MisClientes.Add(unC);
            return true;
        }
        public bool Validar()
        {

            return true;
        }
        
    }
}
