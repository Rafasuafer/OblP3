﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Rol { get; set; }
        public int Ci { get; }
        public string Password { get; set; }


        public static Usuario getUsuarioByCi(int ci) //TERMINAR
        {
            Usuario unU = null;
            return unU;
        }
    }
}
