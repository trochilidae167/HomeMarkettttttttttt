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
    public class NguoiDiChoOnlineAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();


        // PUT: api/NguoiDiChoOnlineAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDiChoOnline(int id, NguoiDiChoOnline nguoiDiChoOnline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDiChoOnline.Id)
            {
                return BadRequest();
            }

            db.Entry(nguoiDiChoOnline).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDiChoOnlineExists(int id)
        {
            return db.NguoiDiChoOnline.Count(e => e.Id == id) > 0;
        }
    }
}