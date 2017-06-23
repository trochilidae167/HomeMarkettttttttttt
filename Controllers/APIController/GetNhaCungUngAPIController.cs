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
using HomeMarket.Common;

namespace HomeMarket.Controllers.APIController
{
    public class GetNhaCungUngAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/GetNhaCungUngAPI
        //public IQueryable<KhachHang> GetKhachHang()
        //{
        //    return db.KhachHang;
        //}

        // GET: api/GetNhaCungUngAPI/5
        //[ResponseType(typeof(KhachHang))]
        //public IHttpActionResult GetKhachHang(int id)
        //{
        //    KhachHang khachHang = db.KhachHang.Find(id);
        //    if (khachHang == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(khachHang);
        //}

        // PUT: api/GetNhaCungUngAPI/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutKhachHang(int id, KhachHang khachHang)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != khachHang.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(khachHang).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KhachHangExists(id))
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

        // POST: api/GetNhaCungUngAPI
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(KhachHang khachHang)
        {
            List<int> list = FindSupplier.LookingForSupplier(khachHang.X, khachHang.Y);
            if (list != null)
            {
                var ncu = db.NhaCungUng.Where(x => list.Contains(x.Id));
                return Ok(ncu);
            }
            else
                return NotFound();

        }

        // DELETE: api/GetNhaCungUngAPI/5
        //[ResponseType(typeof(KhachHang))]
        //public IHttpActionResult DeleteKhachHang(int id)
        //{
        //    KhachHang khachHang = db.KhachHang.Find(id);
        //    if (khachHang == null)
        //    {
        //        return NotFound();
        //    }

        //    db.KhachHang.Remove(khachHang);
        //    db.SaveChanges();

        //    return Ok(khachHang);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhachHangExists(int id)
        {
            return db.KhachHang.Count(e => e.Id == id) > 0;
        }
    }
}