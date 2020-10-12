using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public static ICollection<Usuario> MisUsuarios { get; private set; }
            = new List<Usuario>();

        private string rol;
        private int ci;
        private string password;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public int Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public static Usuario getUsuarioByCi(int ci) //TERMINAR
        {
            Usuario unU = null;
            return unU;
        }
    }
}
