using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeMarket.Models;

namespace HomeMarket.Dao
{
    public class QuanLy
    {
        HomeMarketDbContext db = null;
        public QuanLy()
        {
            db = new HomeMarketDbContext();
        }
        public List<DonHang> DonHangMoi()
        {
            return db.DonHang.Where(x => x.DaNhan == true).ToList();
        }
        public List<KhachHang> KhachHangMoi()
        {
            return db.KhachHang.Where(x => x.Status == false).ToList();
        }
        public List<NguoiDiCho> NguoiDiChoMoi()
        {
            return db.NguoiDiCho.Where(x => x.Status == false).ToList();
        }
        public List<PhanHoi> PhanHoiMoi()
        {
            return db.PhanHoi.Where(x => x.Status == false).ToList();
        }
    }
}