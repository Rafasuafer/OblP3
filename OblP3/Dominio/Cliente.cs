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

    }
}
