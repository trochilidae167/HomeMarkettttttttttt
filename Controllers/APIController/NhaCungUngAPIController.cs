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
using HomeMarket.Models;

namespace HomeMarket.Controllers.APIController
{
    public class NhaCungUngAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/NhaCungUngAPI
        public IQueryable<NhaCungUng> GetNhaCungUng()
        {
            return db.NhaCungUng;
        }

        // GET: api/NhaCungUngAPI/5
        [ResponseType(typeof(NhaCungUng))]
        public IHttpActionResult GetNhaCungUng(int id)
        {
            NhaCungUng nhaCungUng = db.NhaCungUng.Find(id);
            if (nhaCungUng == null)
            {
                return NotFound();
            }

            return Ok(nhaCungUng);
        }

        // PUT: api/NhaCungUngAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhaCungUng(int id, NhaCungUng nhaCungUng)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhaCungUng.Id)
            {
                return BadRequest();
            }

            db.Entry(nhaCungUng).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungUngExists(id))
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

        // POST: api/NhaCungUngAPI
        [ResponseType(typeof(NhaCungUng))]
        public IHttpActionResult PostNhaCungUng(NhaCungUng nhaCungUng)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhaCungUng.Add(nhaCungUng);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhaCungUng.Id }, nhaCungUng);
        }

        // DELETE: api/NhaCungUngAPI/5
        [ResponseType(typeof(NhaCungUng))]
        public IHttpActionResult DeleteNhaCungUng(int id)
        {
            NhaCungUng nhaCungUng = db.NhaCungUng.Find(id);
            if (nhaCungUng == null)
            {
                return NotFound();
            }

            db.NhaCungUng.Remove(nhaCungUng);
            db.SaveChanges();

            return Ok(nhaCungUng);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhaCungUngExists(int id)
        {
            return db.NhaCungUng.Count(e => e.Id == id) > 0;
        }
    }
}