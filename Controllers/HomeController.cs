using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeMarket.Dao;
using HomeMarket.Models;

namespace HomeMarket.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var quanly = new QuanLy();
            ViewBag.DonHangMoi = quanly.DonHangMoi();
            ViewBag.KhachHangMoi = quanly.KhachHangMoi();
            ViewBag.NguoiDiChoMoi = quanly.NguoiDiChoMoi();
            ViewBag.PhanHoiMoi = quanly.PhanHoiMoi();
            return View();
        }
    }
}