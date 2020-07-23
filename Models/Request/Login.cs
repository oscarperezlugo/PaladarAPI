using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaladarAPI.Models.Request
{
    public class Login
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}