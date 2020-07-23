using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PaladarAPI.Models;

namespace PaladarAPI.Controllers
{
    public class CabecerasController : ApiController
    {
        private PaladarMobileEntities5 db = new PaladarMobileEntities5();

        // GET: api/Cabeceras
        public IQueryable<Cabecera> GetCabecera()
        {
            return db.Cabecera;
        }

        // GET: api/Cabeceras/5
        [ResponseType(typeof(Cabecera))]
        public IHttpActionResult GetCabecera(int id)
        {
            Cabecera cabecera = db.Cabecera.Find(id);
            if (cabecera == null)
            {
                return NotFound();
            }

            return Ok(cabecera);
        }

        // PUT: api/Cabeceras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCabecera(int id, Cabecera cabecera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabecera.Row)
            {
                return BadRequest();
            }

            db.Entry(cabecera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabeceraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cabeceras
        [ResponseType(typeof(Cabecera))]
        public IHttpActionResult PostCabecera(Cabecera cabecera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cabecera.Add(cabecera);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cabecera.Row }, cabecera);
        }

        // DELETE: api/Cabeceras/5
        [ResponseType(typeof(Cabecera))]
        public IHttpActionResult DeleteCabecera(int id)
        {
            Cabecera cabecera = db.Cabecera.Find(id);
            if (cabecera == null)
            {
                return NotFound();
            }

            db.Cabecera.Remove(cabecera);
            db.SaveChanges();

            return Ok(cabecera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CabeceraExists(int id)
        {
            return db.Cabecera.Count(e => e.Row == id) > 0;
        }
    }
}