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
        [Route("api/NguoiDiChoAPI/{username}")]
        [ResponseType(typeof(NguoiDiCho))]
        public IHttpActionResult GetNguoiDiCho(string username)
        {
            NguoiDiCho nguoiDiCho = db.NguoiDiCho.SingleOrDefault(x=>x.UserName == username);
            if (nguoiDiCho == null)
            {
                return NotFound();
            }

            return Ok(nguoiDiCho);
        }

        // PUT: api/NguoiDiChoAPI/5
        [Route("api/NguoiDiChoAPI/{username}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDiCho(string username, NguoiDiCho nguoiDiCho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (username != nguoiDiCho.UserName)
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
                if (!NguoiDiChoExists(username))
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
            NguoiDiChoOnlines nguoidichoOnline = new NguoiDiChoOnlines();
            nguoidichoOnline.Id = nguoiDiCho.Id;
            nguoidichoOnline.Online = false;
            nguoidichoOnline.X = 0;
            nguoidichoOnline.Y = 0;
            db.NguoiDiCho.Add(nguoiDiCho);
            db.NguoiDiChoOnline.Add(nguoidichoOnline);
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

        private bool NguoiDiChoExists(string username)
        {
            return db.NguoiDiCho.Count(e => e.UserName == username) > 0;
        }
    }
}