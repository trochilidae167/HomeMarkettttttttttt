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

		   var banggiacho = from s in db.BangGiaCho select s;				   
 	
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
                                       || s.MaThucPham.Contains(searchString));
            }
            
            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
			// có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Gia = sortOrder == "Gia" ? "Gia_desc" : "Gia";
            ViewBag.Loai = sortOrder == "Loai" ? "Loai_desc" : "Loai";
            switch (sortOrder)
            {
                case "Loai":
                    banggiacho = banggiacho.OrderBy(s => s.LoaiThucPham);
                    break;
                case "Loai_desc":
                    banggiacho = banggiacho.OrderByDescending(s => s.LoaiThucPham);
                    break;               
                case "Gia":
                    banggiacho = banggiacho.OrderBy(s => s.GiaThucPham);
                    break;
                default: 
                    banggiacho = banggiacho.OrderByDescending(s => s.GiaThucPham);
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
            return View();
        }

        // POST: /BangGiaCho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MaThucPham,TenThucPham,LoaiThucPham,GiaThucPham")] BangGiaCho bangGiaCho)
        {
            if (ModelState.IsValid)
            {
                db.BangGiaCho.Add(bangGiaCho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(bangGiaCho);
        }

        // POST: /BangGiaCho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MaThucPham,TenThucPham,LoaiThucPham,GiaThucPham")] BangGiaCho bangGiaCho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangGiaCho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
