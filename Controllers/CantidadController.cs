using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaladarAPI.Controllers
{
    public class CantidadController : ApiController
    {
        public IHttpActionResult Add(Models.Request.Cantidades CantDesc)
        {
            using (Models.PaladarMobileEntities11 db = new Models.PaladarMobileEntities11())
            {
                var registro = new Models.Producto();
                {
                    var Cant = db.Producto.FirstOrDefault(u => u.Tag == CantDesc.TagDesc);
                    Cant.Cantidad = Cant.Cantidad - CantDesc.CantidadDesc;                    
                    db.SaveChanges();
                }
                return Json(new { message = "Actualizado" });
            }
        }
    }
}
