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
    public class PagosController : ApiController
    {
        private PaladarMobileEntities12 db = new PaladarMobileEntities12();

        // GET: api/Pagos
        public IQueryable<Pagos> GetPagos()
        {
            return db.Pagos;
        }

        // GET: api/Pagos/5
        [ResponseType(typeof(Pagos))]
        public IHttpActionResult GetPagos(int id)
        {
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return NotFound();
            }

            return Ok(pagos);
        }

        // PUT: api/Pagos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPagos(int id, Pagos pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagos.Row)
            {
                return BadRequest();
            }

            db.Entry(pagos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagosExists(id))
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

        // POST: api/Pagos
        [ResponseType(typeof(Pagos))]
        public IHttpActionResult PostPagos(Pagos pagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pagos.Add(pagos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pagos.Row }, pagos);
        }

        // DELETE: api/Pagos/5
        [ResponseType(typeof(Pagos))]
        public IHttpActionResult DeletePagos(int id)
        {
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return NotFound();
            }

            db.Pagos.Remove(pagos);
            db.SaveChanges();

            return Ok(pagos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PagosExists(int id)
        {
            return db.Pagos.Count(e => e.Row == id) > 0;
        }
    }
}