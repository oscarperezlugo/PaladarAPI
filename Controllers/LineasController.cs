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
    public class LineasController : ApiController
    {
        private PaladarMobileEntities7 db = new PaladarMobileEntities7();

        // GET: api/Lineas
        public IQueryable<Lineas> GetLineas()
        {
            return db.Lineas;
        }

        // GET: api/Lineas/5
        [ResponseType(typeof(Lineas))]
        public IHttpActionResult GetLineas(int id)
        {
            Lineas lineas = db.Lineas.Find(id);
            if (lineas == null)
            {
                return NotFound();
            }

            return Ok(lineas);
        }

        // PUT: api/Lineas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineas(int id, Lineas lineas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineas.Row)
            {
                return BadRequest();
            }

            db.Entry(lineas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineasExists(id))
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

        // POST: api/Lineas
        [ResponseType(typeof(Lineas))]
        public IHttpActionResult PostLineas(Lineas lineas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lineas.Add(lineas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lineas.Row }, lineas);
        }

        // DELETE: api/Lineas/5
        [ResponseType(typeof(Lineas))]
        public IHttpActionResult DeleteLineas(int id)
        {
            Lineas lineas = db.Lineas.Find(id);
            if (lineas == null)
            {
                return NotFound();
            }

            db.Lineas.Remove(lineas);
            db.SaveChanges();

            return Ok(lineas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineasExists(int id)
        {
            return db.Lineas.Count(e => e.Row == id) > 0;
        }
    }
}