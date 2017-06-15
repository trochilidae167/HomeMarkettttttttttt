using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Services;
using System.Web.Http;
using System.Web.Http.Description;
using HomeMarket.Models;
using HomeMarket.Common;

namespace HomeMarket.Controllers
{
    public class KhachHangAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/KhachHangAPI
        public KhachHangAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        //public IQueryable<KhachHang> GetKhachHang()
        //{
        //    return db.KhachHang;
        //}

        // GET: api/KhachHangAPI/5
        [Route("api/KhachHangAPI/{username}")]
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(string username /*int id*/)
        {
            KhachHang khachHang = db.KhachHang.SingleOrDefault(x => x.UserName == username);
            //KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return Ok(khachHang);
        }

        // PUT: api/KhachHangAPI/
        [Route("api/KhachHangAPI/{username}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhachHang(string username, KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (username != khachHang.UserName)
            {
                return BadRequest();
            }

            db.Entry(khachHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachHangExists(username))
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

        // POST: api/KhachHangAPI
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(KhachHang khachHang)
        {
            var khachhang = db.KhachHang;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int result = 1;
            if (khachhang.Count(x => x.UserName == khachHang.UserName) > 0)
                result = -1;
            else if (khachhang.Count(x => x.Email == khachHang.Email) > 0)
                result = -2;
            if (result == 1)
            {
                
                khachHang.Password = Encryptor.MD5Hash(khachHang.Password);
                khachHang.NgayDangKy = DateTime.Now;
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                db.Entry(khachHang).State = EntityState.Modified;
                khachHang.Ma = khachHang.Id.ToString();
                db.SaveChanges();
                return Json("1");
            }
            if (result == -1)
            {
                return Json("-1");
            }
            if (result == -2)
            {
                return Json("-2");
            }
            return Ok();
        }

        // DELETE: api/KhachHangAPI/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult DeleteKhachHang(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            db.KhachHang.Remove(khachHang);
            db.SaveChanges();

            return Ok(khachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhachHangExists(string username)
        {
            return db.KhachHang.Count(e => e.UserName == username) > 0;
        }
    }
}