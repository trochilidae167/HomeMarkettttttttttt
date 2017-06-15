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
using HomeMarket.Common;

namespace HomeMarket.Controllers.APIController
{
    public class NhanDonHangAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: api/NhanDonHangAPI
        //public IQueryable<NhanDonHang> GetNhanDonHang()
        //{
        //    return db.NhanDonHang;
        //}

        // GET: api/NhanDonHangAPI/5
        [ResponseType(typeof(NhanDonHang))]
        public IHttpActionResult GetNhanDonHang(int id)
        {
            NhanDonHang nhanDonHang = db.NhanDonHang.Find(id);
            if (nhanDonHang == null)
            {
                return NotFound();
            }

            return Ok(nhanDonHang);
        }

        // PUT: api/NhanDonHangAPI/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutNhanDonHang(int id, NhanDonHang nhanDonHang)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != nhanDonHang.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(nhanDonHang).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NhanDonHangExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/NhanDonHangAPI
        [ResponseType(typeof(NhanDonHang))]
        public IHttpActionResult PostNhanDonHang(NhanDonHang nhanDonHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var donhang = db.DonHang.SingleOrDefault(x => x.Ma == nhanDonHang.MaDonHang);
            var nguoidicho = db.NguoiDiCho.SingleOrDefault(x => x.Ma == nhanDonHang.MaNguoiDiCho);
            var nguoidichoOnline = db.NguoiDiChoOnline.SingleOrDefault(y=>y.Id == nguoidicho.Id);
            if(nhanDonHang.Status == true)
            {

                nhanDonHang.Id = donhang.Id;
                db.NhanDonHang.Add(nhanDonHang);
                db.SaveChanges();
                string noidung = "Đơn hàng số " + nhanDonHang.MaDonHang + "của bạn đã được Người đi chợ số " + nhanDonHang.MaNguoiDiCho + "chấp nhận."
                                  +"<br>Thông tin chi tiết Người đi chợ: "
                                  +"<br>Họ tên: "+nguoidicho.Ten
                                  +"<br>SĐT: "+nguoidicho.SDT;
                Common.SendNotification.SendNotifications(noidung,"NhanDonHang",donhang.KhachHangId);
                nguoidicho.TaiKhoan = nguoidicho.TaiKhoan - 5000;
                string trutaikhoan = "Tài khoản của bạn đã bị trừ 5000đ phí dịch vụ vì bạn đã nhận thực hiện đơn hàng số " + nhanDonHang.MaDonHang;
                SendNotification.SendNotifications(trutaikhoan, "TruTaiKhoan", nguoidicho.Id);

            }
            if (nhanDonHang.Status == false)
            {
                nguoidichoOnline.Refuse = nhanDonHang.Id;
                db.SaveChanges();
                string donhangchitiet = "";
                List<int> list = new List<int>();
                var m = db.DonHangChiTiet.Where(x => x.DonHangId == donhang.Id);
                long n = m.Count();
                double tongtien = 0;
                foreach (DonHangChiTiet x in m)
                {
                    list.Add(x.Id);
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    donhangchitiet = donhangchitiet + "Tên thực phẩm:" + db.DonHangChiTiet.Find(list[i]).TenThucPham +
                                      "<br>Số lượng:" + db.DonHangChiTiet.Find(list[i]).SoLuong + "/kg" +
                                      "<br>Giá tiền:" + db.DonHangChiTiet.Find(list[i]).Gia + "/VND" + "<br>";
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    tongtien = tongtien + db.DonHangChiTiet.Find(list[i]).Gia;
                }
                string noidung = "";
                noidung = "Đơn hàng " + donhang.Id + " từ khách hàng có mã là: " + donhang.KhachHangId + "<br>Với đơn hàng như sau:<br>" 
                    + donhangchitiet  +"Tổng số tiền là: " + tongtien  +
                    "Khách hàng yêu cầu thực phẩm được mua ở: Siêu thị A";
                FindShipper.LookingForShipper(donhang.X,donhang.Y, noidung, "YeuCauNhanDonHang-" + donhang.Id, donhang.Id);
            }

            
            return Json("");
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (NhanDonHangExists(nhanDonHang.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = nhanDonHang.Id }, nhanDonHang);
        }

        // DELETE: api/NhanDonHangAPI/5
        //[ResponseType(typeof(NhanDonHang))]
        //public IHttpActionResult DeleteNhanDonHang(int id)
        //{
        //    NhanDonHang nhanDonHang = db.NhanDonHang.Find(id);
        //    if (nhanDonHang == null)
        //    {
        //        return NotFound();
        //    }

        //    db.NhanDonHang.Remove(nhanDonHang);
        //    db.SaveChanges();

        //    return Ok(nhanDonHang);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhanDonHangExists(int id)
        {
            return db.NhanDonHang.Count(e => e.Id == id) > 0;
        }
    }
}