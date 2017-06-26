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
    public class NguoiDiChoOnlineAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/NguoiDiChoOnlineAPI
        public IQueryable<NguoiDiChoOnlines> GetNguoiDiChoOnline()
        {
            return db.NguoiDiChoOnline;
        }

        // GET: api/NguoiDiChoOnlineAPI/5
        [ResponseType(typeof(NguoiDiChoOnlines))]
        public IHttpActionResult GetNguoiDiChoOnlines(int id)
        {
            NguoiDiChoOnlines nguoiDiChoOnlines = db.NguoiDiChoOnline.Find(id);
            if (nguoiDiChoOnlines == null)
            {
                return NotFound();
            }

            return Ok(nguoiDiChoOnlines);
        }

        // PUT: api/NguoiDiChoOnlineAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDiChoOnlines(int id, NguoiDiChoOnlines nguoiDiChoOnlines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDiChoOnlines.Id)
            {
                return BadRequest();
            }

            db.Entry(nguoiDiChoOnlines).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDiChoOnlinesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Json("Cập nhật thành công");
        }

        // POST: api/NguoiDiChoOnlineAPI
        //[ResponseType(typeof(KhachHang))]
        //public IHttpActionResult PostKhachHang(KhachHang khachHang)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    List<int> list = FindSupplier.LookingForSupplier(khachHang.X, khachHang.Y);
        //    if (list != null)
        //    {
        //        var ncu = db.NhaCungUng.Where(x => list.Contains(x.Id));
        //        return Ok(ncu);
        //    }
        //    else
        //        return NotFound();
        //}

        // DELETE: api/NguoiDiChoOnlineAPI/5
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDiChoOnlinesExists(int id)
        {
            return db.NguoiDiChoOnline.Count(e => e.Id == id) > 0;
        }
    }
}