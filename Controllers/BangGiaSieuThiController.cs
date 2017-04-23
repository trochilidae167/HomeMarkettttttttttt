using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeMarket.Models;
using HomeMarket.Common;
using PagedList;

namespace HomeMarket.Controllers
{
    public class BangGiaSieuThiController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /BangGiaSieuThi/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page){

		   var banggiasieuthis = from s in db.BangGiaSieuThi select s;				   
 	
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
                banggiasieuthis = banggiasieuthis.Where(s => s.TenThucPham.Contains(searchString)
                                       || s.LoaiThucPham.Contains(searchString));
            }
            
            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
			// có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Loai = sortOrder == "Loai" ? "Loai_desc" : "Loai";
            ViewBag.Gia = sortOrder == "Gia" ? "Gia_desc" : "Gia";
            switch (sortOrder)
            {
                case "Loai":
                    banggiasieuthis = banggiasieuthis.OrderBy(s => s.LoaiThucPham);
                    break;
                case "Loai_desc":
                    banggiasieuthis = banggiasieuthis.OrderByDescending(s => s.LoaiThucPham);
                    break;               
                case "Gia":
                    banggiasieuthis = banggiasieuthis.OrderBy(s => s.GiaThucPham);
                    break;
                default: 
                    banggiasieuthis = banggiasieuthis.OrderByDescending(s => s.GiaThucPham);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			
			return View(banggiasieuthis.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /BangGiaSieuThi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGiaSieuThi bangGiaSieuThi = db.BangGiaSieuThi.Find(id);
            if (bangGiaSieuThi == null)
            {
                return HttpNotFound();
            }
            return View(bangGiaSieuThi);
        }

        // GET: /BangGiaSieuThi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BangGiaSieuThi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MaThucPham,TenThucPham,LoaiThucPham,GiaThucPham,Status")] BangGiaSieuThi bangGiaSieuThi)
        {
            if (ModelState.IsValid)
            {
                db.BangGiaSieuThi.Add(bangGiaSieuThi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangGiaSieuThi);
        }

        // GET: /BangGiaSieuThi/Edit/5\
        [HasCredential(RoleID = "EDIT_BANGGIA")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGiaSieuThi bangGiaSieuThi = db.BangGiaSieuThi.Find(id);
            if (bangGiaSieuThi == null)
            {
                return HttpNotFound();
            }
            return View(bangGiaSieuThi);
        }

        // POST: /BangGiaSieuThi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include= "Id,MaThucPham,TenThucPham,LoaiThucPham,GiaThucPham,Status")] BangGiaSieuThi bangGiaSieuThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangGiaSieuThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangGiaSieuThi);
        }

        // GET: /BangGiaSieuThi/Delete/5
        [HasCredential(RoleID = "DELETE_BANGGIA")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGiaSieuThi bangGiaSieuThi = db.BangGiaSieuThi.Find(id);
            if (bangGiaSieuThi == null)
            {
                return HttpNotFound();
            }
            return View(bangGiaSieuThi);
        }

        // POST: /BangGiaSieuThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangGiaSieuThi bangGiaSieuThi = db.BangGiaSieuThi.Find(id);
            db.BangGiaSieuThi.Remove(bangGiaSieuThi);
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
