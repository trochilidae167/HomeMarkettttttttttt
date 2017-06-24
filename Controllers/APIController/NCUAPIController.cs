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
    public class NCUAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/NCUAPI
        public IQueryable<KhachHang> GetKhachHang()
        {
            return db.KhachHang;
        }

        // GET: api/NCUAPI/5
     

        // POST: api/NCUAPI
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<int> list = FindSupplier.LookingForSupplier(khachHang.X, khachHang.Y);
            if (list != null)
            {
                var ncu = db.NhaCungUng.Where(x => list.Contains(x.Id));
                return Ok(ncu);
            }
            else
                return NotFound();
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}