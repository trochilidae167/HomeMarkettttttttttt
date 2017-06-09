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
    public class PhanHoiController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /PhanHoi/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page){

           var phanhoi = db.PhanHoi.Include(p => p.KhachHang);		
 	
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
                phanhoi = phanhoi.Where(s => s.KhachHang.Ten.Contains(searchString));
            }
            
            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
			// có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.KhachHang = sortOrder == "KhachHang" ? "KhachHang_desc" : "KhachHang";
            ViewBag.Status = sortOrder == "Status" ? "Status_desc" : "Status";
            switch (sortOrder)
            {
                case "KhachHang":
                    phanhoi = phanhoi.OrderBy(s => s.KhachHang.Ten);
                    break;
                case "KhachHang_desc":
                    phanhoi = phanhoi.OrderByDescending(s => s.KhachHang.Ten);
                    break;               
                case "Status":
                    phanhoi = phanhoi.OrderBy(s => s.Status == true);
                    break;
                default: 
                    phanhoi = phanhoi.OrderByDescending(s => s.Status == false);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			
			return View(phanhoi.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /PhanHoi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return HttpNotFound();
            }
            return View(phanHoi);
        }

        // GET: /PhanHoi/Create
        public ActionResult Create()
        {
            ViewBag.KhachHangId = new SelectList(db.KhachHang, "Id", "Ten");
            return View();
        }

        // POST: /PhanHoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,KhachHangId,NoiDung,NgayTao,Status")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                db.PhanHoi.Add(phanHoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHangId = new SelectList(db.KhachHang, "Id", "Ten", phanHoi.KhachHangId);
            return View(phanHoi);
        }

        // GET: /PhanHoi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHangId = new SelectList(db.KhachHang, "Id", "Ten", phanHoi.KhachHangId);
            return View(phanHoi);
        }

        // POST: /PhanHoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,KhachHangId,NoiDung,NgayTao,Status")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanHoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHangId = new SelectList(db.KhachHang, "Id", "Ten", phanHoi.KhachHangId);
            return View(phanHoi);
        }

        // GET: /PhanHoi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return HttpNotFound();
            }
            return View(phanHoi);
        }

        // POST: /PhanHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            db.PhanHoi.Remove(phanHoi);
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
