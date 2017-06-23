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
    public class NguoiDiChoController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /NguoiDiCho/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page){

		   var nguoidicho = from s in db.NguoiDiCho select s;				   
 	
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
                nguoidicho = nguoidicho.Where(s => s.Ma.Contains(searchString)
                                       || s.Ten.Contains(searchString));
            }
            
            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
			// có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NgayDangKy = sortOrder == "NgayDangKy" ? "NgayDangKy_desc" : "NgayDangKy";
            ViewBag.Ma = sortOrder == "Ma" ? "Ma_desc" : "Ma";
            switch (sortOrder)
            {
                case "Ma":
                    nguoidicho = nguoidicho.OrderBy(s => s.Ma);
                    break;
                case "Ma_desc":
                    nguoidicho = nguoidicho.OrderByDescending(s => s.Ma);
                    break;               
                case "NgayDangKy":
                    nguoidicho = nguoidicho.OrderBy(s => s.NgayDangKy);
                    break;
                default: 
                    nguoidicho = nguoidicho.OrderByDescending(s => s.NgayDangKy);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			
			return View(nguoidicho.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /NguoiDiCho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDiCho nguoiDiCho = db.NguoiDiCho.Find(id);
            if (nguoiDiCho == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDiCho);
        }

        // GET: /NguoiDiCho/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NguoiDiCho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Ma,Ten,HinhAnh,NgaySinh,QuocTich,SDT,CMND,DiaChi,Email,DanhGia,TaiKhoan,NgayDangKy")] NguoiDiCho nguoiDiCho)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDiCho.Add(nguoiDiCho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoiDiCho);
        }

        // GET: /NguoiDiCho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDiCho nguoiDiCho = db.NguoiDiCho.Find(id);
            if (nguoiDiCho == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDiCho);
        }

        // POST: /NguoiDiCho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Ma,Ten,HinhAnh,NgaySinh,QuocTich,SDT,CMND,DiaChi,Email,Status,DanhGia,TaiKhoan,NgayDangKy")] NguoiDiCho nguoiDiCho)
        {
            if (ModelState.IsValid)
            {
                var khachhang = db.KhachHang.SingleOrDefault(x => x.Id == nguoiDiCho.Id);
                if (nguoiDiCho.Status == true)
                {
                    khachhang.NguoiDiCho = true;
                }
                db.Entry(nguoiDiCho).State = EntityState.Modified;
                db.Entry(khachhang).State = EntityState.Modified;
              
                db.SaveChanges();
                if(nguoiDiCho.Status == true)
                {
                    string noidung = "Hệ thống đã xét duyệt thành công thông tin đăng ký làm người đi chợ của bạn! Bây giờ bạn có thể nhận các đơn hàng từ hệ thống!";
                    Common.SendNotification.SendNotifications(noidung,"Thông báo từ hệ thống",nguoiDiCho.Id);
                }
                return RedirectToAction("Index");
            }
            return View(nguoiDiCho);
        }

        // GET: /NguoiDiCho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDiCho nguoiDiCho = db.NguoiDiCho.Find(id);
            if (nguoiDiCho == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDiCho);
        }

        // POST: /NguoiDiCho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDiCho nguoiDiCho = db.NguoiDiCho.Find(id);
            db.NguoiDiCho.Remove(nguoiDiCho);
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
