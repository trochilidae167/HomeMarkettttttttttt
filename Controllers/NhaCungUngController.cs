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
    public class NhaCungUngController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /NhaCungUng/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page){

		   var nhacungung = from s in db.NhaCungUng select s;				   
 	
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
                nhacungung = nhacungung.Where(s => s.Ten.Contains(searchString)
                                       || s.Ma.Contains(searchString));
            }
            
            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
			// có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Ten = sortOrder == "Ten" ? "Ten_desc" : "Ten";
            ViewBag.Ma = sortOrder == "Ma" ? "Ma_desc" : "Ma";
            switch (sortOrder)
            {
                case "Ten":
                    nhacungung = nhacungung.OrderBy(s => s.Ten);
                    break;
                case "Ten_desc":
                    nhacungung = nhacungung.OrderByDescending(s => s.Ten);
                    break;               
                case "Ma":
                    nhacungung = nhacungung.OrderBy(s => s.Ma);
                    break;
                default: 
                    nhacungung = nhacungung.OrderByDescending(s => s.Ma);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			
			return View(nhacungung.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /NhaCungUng/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungUng nhaCungUng = db.NhaCungUng.Find(id);
            if (nhaCungUng == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungUng);
        }

        // GET: /NhaCungUng/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NhaCungUng/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Ma,Ten,DiaChi,X,Y")] NhaCungUng nhaCungUng)
        {
            if (ModelState.IsValid)
            {
                db.NhaCungUng.Add(nhaCungUng);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaCungUng);
        }

        // GET: /NhaCungUng/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungUng nhaCungUng = db.NhaCungUng.Find(id);
            if (nhaCungUng == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungUng);
        }

        // POST: /NhaCungUng/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Ma,Ten,DiaChi,X,Y")] NhaCungUng nhaCungUng)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaCungUng).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaCungUng);
        }

        // GET: /NhaCungUng/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungUng nhaCungUng = db.NhaCungUng.Find(id);
            if (nhaCungUng == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungUng);
        }

        // POST: /NhaCungUng/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaCungUng nhaCungUng = db.NhaCungUng.Find(id);
            db.NhaCungUng.Remove(nhaCungUng);
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
