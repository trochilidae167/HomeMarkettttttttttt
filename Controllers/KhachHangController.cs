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
using HomeMarket.Common;

namespace HomeMarket.Controllers
{
    public class KhachHangController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /KhachHang/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var khachhangs = from s in db.KhachHang select s;

            //Search            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                //AttributeSearch, AttributeSearch2 là những trường sẽ đem so sánh với nội dung tìm kiếm, cần thay đổi cho phù hợp
                khachhangs = khachhangs.Where(s => s.Ma.Contains(searchString)
                                       || s.Ten.Contains(searchString));
            }

            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
            // có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NgayDangKy = sortOrder == "NgayDangKy" ? "NgayDangKy_desc" : "NgayDangKy";
            ViewBag.Ma = sortOrder == "Ma" ? "Ma_desc" : "Ma";
            ViewBag.Status = sortOrder == "Status" ? "Status_desc" : "Status";
            switch (sortOrder)
            {
                case "Ma":
                    khachhangs = khachhangs.OrderBy(s => s.Ma);
                    break;
                case "Ma_desc":
                    khachhangs = khachhangs.OrderByDescending(s => s.Ma);
                    break;
                case "Status":
                    khachhangs = khachhangs.OrderBy(s => s.Status == false);
                    break;
                case "Status_desc":
                    khachhangs = khachhangs.OrderByDescending(s => s.Status == true);
                    break;
                case "NgayDangKy":
                    khachhangs = khachhangs.OrderBy(s => s.NgayDangKy);
                    break;
                default:
                    khachhangs = khachhangs.OrderByDescending(s => s.NgayDangKy);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(khachhangs.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: /KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /KhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ma,Ten,UserName,Password,HinhAnh,NgaySinh,QuocTich,SDT,DiaChi,Email,NgayDangKy,NguoiDiCho")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.Password = Encryptor.MD5Hash(khachHang.Password);
                khachHang.NgayDangKy = DateTime.Now;
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: /KhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: /KhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ma,Ten,UserName,Password,HinhAnh,NgaySinh,QuocTich,SDT,DiaChi,Email,NgayDangKy,NguoiDiCho")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {

                db.Entry(khachHang).State = EntityState.Modified;
                khachHang.NgayDangKy = DateTime.Now;
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: /KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: /KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang.NguoiDiCho == true)
            {
                var nguoidicho = db.NguoiDiCho.SingleOrDefault(x => x.Id == id);
                var nguoidichoOnline = db.NguoiDiChoOnline.SingleOrDefault(x => x.Id == id);
                db.KhachHang.Remove(khachHang);
                db.NguoiDiChoOnline.Remove(nguoidichoOnline);
                db.NguoiDiCho.Remove(nguoidicho);
                db.SaveChanges();
            }
            else
            {
                db.KhachHang.Remove(khachHang);
                db.SaveChanges();
            }
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
