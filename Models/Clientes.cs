//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaladarAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public string Contrasena { get; set; }
        public Nullable<System.Guid> iDCliente { get; set; }
        public int Row { get; set; }
    }
}
