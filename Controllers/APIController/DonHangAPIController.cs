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
    public class DonHangAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        //public DonHangAPIController()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //}
        // GET: api/DonHangAPI
        public IQueryable<DonHang> GetDonHang()
        {
            return db.DonHang;
        }

        // GET: api/DonHangAPI/5
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult GetDonHang(int id)
        {
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return NotFound();
            }

            return Ok(donHang);
        }

        // PUT: api/DonHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonHang(int id, DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donHang.Id)
            {
                return BadRequest();
            }

            db.Entry(donHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangExists(id))
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

        // POST: api/DonHangAPI
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult PostDonHang(DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            donHang.DonHangChiTiets.Count();
            donHang.Ma = DateTime.Now.ToString("ddmmyyyy")+donHang.Id;
            donHang.ThoiGianDat = DateTime.Now;
            donHang.DaNhan = false;
            db.DonHang.Add(donHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donHang.Id }, donHang);
        }

        // DELETE: api/DonHangAPI/5
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult DeleteDonHang(int id)
        {
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return NotFound();
            }

            db.DonHang.Remove(donHang);
            db.SaveChanges();

            return Ok(donHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonHangExists(int id)
        {
            return db.DonHang.Count(e => e.Id == id) > 0;
        }
    }
}