using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeMarket.Models;
using PagedList;

namespace HomeMarket.Controllers
{
    public class BangGiaChoController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /BangGiaCho/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page){

           var banggiacho = db.BangGiaCho.Include(b => b.NCU);		
 	
			 //Search            
            if (searchString != null) {
                page = 1;
            }
            else {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
				//AttributeSearch, AttributeSearch2 là những trường sẽ đem so sánh với nội dung tìm kiếm, cần thay đổi cho phù hợp
                banggiacho = banggiacho.Where(s => s.TenThucPham.Contains(searchString)
                                       || s.MaThucPham.Contains(searchString)
                                       || s.NCU.Ten.Contains(searchString));
            }
            
            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
			// có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TenThucPham = sortOrder == "TenThucPham" ? "TenThucPham_desc" : "TenThucPham";
            ViewBag.MaThucPham = sortOrder == "MaThucPham" ? "MaThucPham_desc" : "MaThucPham";
            ViewBag.NCUId = sortOrder == "NCUId" ? "NCUId_desc" : "NCUId";
            switch (sortOrder)
            {
               
                case "TenThucPham":
                    banggiacho = banggiacho.OrderBy(s => s.TenThucPham);
                    break;
                case "TenThucPham_desc":
                    banggiacho = banggiacho.OrderByDescending(s => s.TenThucPham);
                    break;               
                case "NCUId":
                    banggiacho = banggiacho.OrderBy(s => s.NCU.Ten);
                    break;
                default: 
                    banggiacho = banggiacho.OrderByDescending(s => s.NCU.Ten);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			
			return View(banggiacho.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /BangGiaCho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGiaCho bangGiaCho = db.BangGiaCho.Find(id);
            if (bangGiaCho == null)
            {
                return HttpNotFound();
            }
            return View(bangGiaCho);
        }

        // GET: /BangGiaCho/Create
        public ActionResult Create()
        {
            ViewBag.NCUId = new SelectList(db.NhaCungUng, "Id", "Ten");
            return View();
        }

        // POST: /BangGiaCho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NCUId,MaThucPham,TenThucPham,LoaiThucPham,GiaThucPham,Status")] BangGiaCho bangGiaCho)
        {
            if (ModelState.IsValid)
            {
                db.BangGiaCho.Add(bangGiaCho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NCUId = new SelectList(db.NhaCungUng, "Id", "Ten", bangGiaCho.NCUId);
            return View(bangGiaCho);
        }

        // GET: /BangGiaCho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGiaCho bangGiaCho = db.BangGiaCho.Find(id);
            if (bangGiaCho == null)
            {
                return HttpNotFound();
            }
            ViewBag.NCUId = new SelectList(db.NhaCungUng, "Id", "Ten", bangGiaCho.NCUId);
            return View(bangGiaCho);
        }

        // POST: /BangGiaCho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NCUId,MaThucPham,TenThucPham,LoaiThucPham,GiaThucPham,Status")] BangGiaCho bangGiaCho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangGiaCho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NCUId = new SelectList(db.NhaCungUng, "Id", "Ten", bangGiaCho.NCUId);
            return View(bangGiaCho);
        }

        // GET: /BangGiaCho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGiaCho bangGiaCho = db.BangGiaCho.Find(id);
            if (bangGiaCho == null)
            {
                return HttpNotFound();
            }
            return View(bangGiaCho);
        }

        // POST: /BangGiaCho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangGiaCho bangGiaCho = db.BangGiaCho.Find(id);
            db.BangGiaCho.Remove(bangGiaCho);
            db.SaveChanges();
            return RedirectToAction("Index");
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
