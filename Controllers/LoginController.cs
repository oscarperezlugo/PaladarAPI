using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaladarAPI.Controllers
{
    public class LoginController : ApiController
    {
        string TokenRes;
        int ID;
        string Nombre;
        string Apellido;
        string Direccion;
        string Telefono;
        string Correo;
        System.Guid? IDC;
        public IHttpActionResult VerifyPassword(Models.Request.Login user)
        {
            Models.PaladarMobileEntities6 db = new Models.PaladarMobileEntities6();
            {
                var myUser = db.Clientes.FirstOrDefault(u => u.Correo == user.Correo && u.Contrasena == user.Contrasena);
                if (myUser != null)
                {
                    string token = Guid.NewGuid().ToString();
                    ID = myUser.Row;
                    TokenRes = token;
                    Nombre = myUser.Nombre;
                    Apellido = myUser.Apellido;
                    Direccion = myUser.Direccion;
                    Telefono = myUser.Telefono;
                    Correo = myUser.Correo;
                    IDC = myUser.iDCliente;
                }
                else
                {
                    string token = "0";
                    TokenRes = token;
                    ID = 0;
                }
                return Json(new { Token = TokenRes.ToString(), iD = ID, nombre = Nombre, apellido = Apellido, direccion = Direccion, telefono = Telefono, correolog = Correo,  guid = IDC  }); ;
            }
        }
    }
}
