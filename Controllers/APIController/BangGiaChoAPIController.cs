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
    public class BangGiaChoAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/BangGiaChoAPI
        public IQueryable<BangGiaCho> GetBangGiaCho()
        {
            return db.BangGiaCho;
        }

        // GET: api/BangGiaChoAPI/5
        [ResponseType(typeof(BangGiaCho))]
        public IHttpActionResult GetBangGiaCho(int id)
        {
            BangGiaCho bangGiaCho = db.BangGiaCho.Find(id);
            if (bangGiaCho == null)
            {
                return NotFound();
            }

            return Ok(bangGiaCho);
        }

        // PUT: api/BangGiaChoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBangGiaCho(int id, BangGiaCho bangGiaCho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bangGiaCho.Id)
            {
                return BadRequest();
            }

            db.Entry(bangGiaCho).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BangGiaChoExists(id))
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

        // POST: api/BangGiaChoAPI
        [ResponseType(typeof(BangGiaCho))]
        public IHttpActionResult PostBangGiaCho(BangGiaCho bangGiaCho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BangGiaCho.Add(bangGiaCho);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bangGiaCho.Id }, bangGiaCho);
        }

        // DELETE: api/BangGiaChoAPI/5
        [ResponseType(typeof(BangGiaCho))]
        public IHttpActionResult DeleteBangGiaCho(int id)
        {
            BangGiaCho bangGiaCho = db.BangGiaCho.Find(id);
            if (bangGiaCho == null)
            {
                return NotFound();
            }

            db.BangGiaCho.Remove(bangGiaCho);
            db.SaveChanges();

            return Ok(bangGiaCho);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BangGiaChoExists(int id)
        {
            return db.BangGiaCho.Count(e => e.Id == id) > 0;
        }
    }
}