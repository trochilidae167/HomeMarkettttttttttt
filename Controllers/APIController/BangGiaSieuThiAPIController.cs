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
    public class BangGiaSieuThiAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/BangGiaSieuThiAPI
        public IQueryable<BangGiaSieuThi> GetBangGiaSieuThi()
        {
            return db.BangGiaSieuThi;
        }

        // GET: api/BangGiaSieuThiAPI/5
        [ResponseType(typeof(BangGiaSieuThi))]
        public IHttpActionResult GetBangGiaSieuThi(int id)
        {
            BangGiaSieuThi bangGiaSieuThi = db.BangGiaSieuThi.Find(id);
            if (bangGiaSieuThi == null)
            {
                return NotFound();
            }

            return Ok(bangGiaSieuThi);
        }

        // PUT: api/BangGiaSieuThiAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBangGiaSieuThi(int id, BangGiaSieuThi bangGiaSieuThi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bangGiaSieuThi.Id)
            {
                return BadRequest();
            }

            db.Entry(bangGiaSieuThi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BangGiaSieuThiExists(id))
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

        // POST: api/BangGiaSieuThiAPI
        //[ResponseType(typeof(BangGiaSieuThi))]
        //public IHttpActionResult PostBangGiaSieuThi(BangGiaSieuThi bangGiaSieuThi)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.BangGiaSieuThi.Add(bangGiaSieuThi);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = bangGiaSieuThi.Id }, bangGiaSieuThi);
        //}

        // DELETE: api/BangGiaSieuThiAPI/5
        //[ResponseType(typeof(BangGiaSieuThi))]
        //public IHttpActionResult DeleteBangGiaSieuThi(int id)
        //{
        //    BangGiaSieuThi bangGiaSieuThi = db.BangGiaSieuThi.Find(id);
        //    if (bangGiaSieuThi == null)
        //    {
        //        return NotFound();
        //    }

        //    db.BangGiaSieuThi.Remove(bangGiaSieuThi);
        //    db.SaveChanges();

        //    return Ok(bangGiaSieuThi);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool BangGiaSieuThiExists(int id)
        {
            return db.BangGiaSieuThi.Count(e => e.Id == id) > 0;
        }
    }
}