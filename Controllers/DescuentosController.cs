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
    public class DescuentosController : ApiController
    {
        private PaladarMobileEntities10 db = new PaladarMobileEntities10();

        // GET: api/Descuentos
        public IQueryable<Descuentos> GetDescuentos()
        {
            return db.Descuentos;
        }

        // GET: api/Descuentos/5
        [ResponseType(typeof(Descuentos))]
        public IHttpActionResult GetDescuentos(int id)
        {
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return NotFound();
            }

            return Ok(descuentos);
        }

        // PUT: api/Descuentos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDescuentos(int id, Descuentos descuentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != descuentos.Row)
            {
                return BadRequest();
            }

            db.Entry(descuentos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescuentosExists(id))
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

        // POST: api/Descuentos
        [ResponseType(typeof(Descuentos))]
        public IHttpActionResult PostDescuentos(Descuentos descuentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Descuentos.Add(descuentos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = descuentos.Row }, descuentos);
        }

        // DELETE: api/Descuentos/5
        [ResponseType(typeof(Descuentos))]
        public IHttpActionResult DeleteDescuentos(int id)
        {
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return NotFound();
            }

            db.Descuentos.Remove(descuentos);
            db.SaveChanges();

            return Ok(descuentos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DescuentosExists(int id)
        {
            return db.Descuentos.Count(e => e.Row == id) > 0;
        }
    }
}