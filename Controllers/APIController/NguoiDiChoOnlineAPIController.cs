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
        [ResponseType(typeof(NguoiDiChoOnlines))]
        public IHttpActionResult PostNguoiDiChoOnlines(NguoiDiChoOnlines nguoiDiChoOnlines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NguoiDiChoOnline.Add(nguoiDiChoOnlines);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NguoiDiChoOnlinesExists(nguoiDiChoOnlines.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nguoiDiChoOnlines.Id }, nguoiDiChoOnlines);
        }

        // DELETE: api/NguoiDiChoOnlineAPI/5
        [ResponseType(typeof(NguoiDiChoOnlines))]
        public IHttpActionResult DeleteNguoiDiChoOnlines(int id)
        {
            NguoiDiChoOnlines nguoiDiChoOnlines = db.NguoiDiChoOnline.Find(id);
            if (nguoiDiChoOnlines == null)
            {
                return NotFound();
            }

            db.NguoiDiChoOnline.Remove(nguoiDiChoOnlines);
            db.SaveChanges();

            return Ok(nguoiDiChoOnlines);
        }

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