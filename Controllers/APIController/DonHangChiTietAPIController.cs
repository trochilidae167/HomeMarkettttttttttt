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
    public class DonHangChiTietAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/DonHangChiTietAPI
        public IQueryable<DonHangChiTiet> GetDonHangChiTiet()
        {
            return db.DonHangChiTiet;
        }

        // GET: api/DonHangChiTietAPI/5
        [ResponseType(typeof(DonHangChiTiet))]
        public IHttpActionResult GetDonHangChiTiet(int id)
        {
            DonHangChiTiet donHangChiTiet = db.DonHangChiTiet.Find(id);
            if (donHangChiTiet == null)
            {
                return NotFound();
            }

            return Ok(donHangChiTiet);
        }

        // PUT: api/DonHangChiTietAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonHangChiTiet(int id, DonHangChiTiet donHangChiTiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donHangChiTiet.Id)
            {
                return BadRequest();
            }

            db.Entry(donHangChiTiet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangChiTietExists(id))
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

        // POST: api/DonHangChiTietAPI
        [ResponseType(typeof(DonHangChiTiet))]
        public IHttpActionResult PostDonHangChiTiet(DonHangChiTiet donHangChiTiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DonHangChiTiet.Add(donHangChiTiet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donHangChiTiet.Id }, donHangChiTiet);
        }

        // DELETE: api/DonHangChiTietAPI/5
        [ResponseType(typeof(DonHangChiTiet))]
        public IHttpActionResult DeleteDonHangChiTiet(int id)
        {
            DonHangChiTiet donHangChiTiet = db.DonHangChiTiet.Find(id);
            if (donHangChiTiet == null)
            {
                return NotFound();
            }

            db.DonHangChiTiet.Remove(donHangChiTiet);
            db.SaveChanges();

            return Ok(donHangChiTiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonHangChiTietExists(int id)
        {
            return db.DonHangChiTiet.Count(e => e.Id == id) > 0;
        }
    }
}