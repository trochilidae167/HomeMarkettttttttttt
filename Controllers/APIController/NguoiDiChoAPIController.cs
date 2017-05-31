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
    public class NguoiDiChoAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/NguoiDiChoAPI
        //public IQueryable<NguoiDiCho> GetNguoiDiCho()
        //{
        //    return db.NguoiDiCho;
        //}

        // GET: api/NguoiDiChoAPI/5
        [ResponseType(typeof(NguoiDiCho))]
        public IHttpActionResult GetNguoiDiCho(int id)
        {
            NguoiDiCho nguoiDiCho = db.NguoiDiCho.Find(id);
            if (nguoiDiCho == null)
            {
                return NotFound();
            }

            return Ok(nguoiDiCho);
        }

        // PUT: api/NguoiDiChoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDiCho(int id, NguoiDiCho nguoiDiCho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDiCho.Id)
            {
                return BadRequest();
            }

            db.Entry(nguoiDiCho).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDiChoExists(id))
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

        // POST: api/NguoiDiChoAPI
        [ResponseType(typeof(NguoiDiCho))]
        public IHttpActionResult PostNguoiDiCho(NguoiDiCho nguoiDiCho)
        {
            var khachhang = db.KhachHang.SingleOrDefault(x=>x.Id == nguoiDiCho.Id);
            khachhang.NguoiDiCho = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            nguoiDiCho.Status = false;
            nguoiDiCho.NgayDangKy = DateTime.Now;
            db.NguoiDiCho.Add(nguoiDiCho);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nguoiDiCho.Id }, nguoiDiCho);
        }

        // DELETE: api/NguoiDiChoAPI/5
        //[ResponseType(typeof(NguoiDiCho))]
        //public IHttpActionResult DeleteNguoiDiCho(int id)
        //{
        //    NguoiDiCho nguoiDiCho = db.NguoiDiCho.Find(id);
        //    if (nguoiDiCho == null)
        //    {
        //        return NotFound();
        //    }

        //    db.NguoiDiCho.Remove(nguoiDiCho);
        //    db.SaveChanges();

        //    return Ok(nguoiDiCho);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDiChoExists(int id)
        {
            return db.NguoiDiCho.Count(e => e.Id == id) > 0;
        }
    }
}