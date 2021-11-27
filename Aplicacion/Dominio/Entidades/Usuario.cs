using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string Rol { get; set; }

        public bool Entro {get; set;}

    }
}