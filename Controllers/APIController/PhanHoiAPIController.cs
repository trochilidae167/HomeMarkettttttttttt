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
    public class PhanHoiAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/PhanHoiAPI
        //public IQueryable<PhanHoi> GetPhanHoi()
        //{
        //    return db.PhanHoi;
        //}

        // GET: api/PhanHoiAPI/5
        [ResponseType(typeof(PhanHoi))]
        public IHttpActionResult GetPhanHoi(int id)
        {
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            return Ok(phanHoi);
        }

        // PUT: api/PhanHoiAPI/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPhanHoi(int id, PhanHoi phanHoi)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != phanHoi.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(phanHoi).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PhanHoiExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/PhanHoiAPI
        [ResponseType(typeof(PhanHoi))]
        public IHttpActionResult PostPhanHoi(PhanHoi phanHoi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            phanHoi.NgayTao = DateTime.Now;
            phanHoi.Status = false;
            db.PhanHoi.Add(phanHoi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phanHoi.Id }, phanHoi);
        }

        // DELETE: api/PhanHoiAPI/5
        //[ResponseType(typeof(PhanHoi))]
        //public IHttpActionResult DeletePhanHoi(int id)
        //{
        //    PhanHoi phanHoi = db.PhanHoi.Find(id);
        //    if (phanHoi == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PhanHoi.Remove(phanHoi);
        //    db.SaveChanges();

        //    return Ok(phanHoi);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhanHoiExists(int id)
        {
            return db.PhanHoi.Count(e => e.Id == id) > 0;
        }
    }
}