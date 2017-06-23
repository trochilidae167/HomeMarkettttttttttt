using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeMarket.Common;
using HomeMarket.Models;
namespace HomeMarket.Common
{
    public class FindShipper
    {
        private static HomeMarketDbContext db = new HomeMarketDbContext();
        public static string LookingForShipper(double x, double y,string noidung,string tieude,int donhangId,int khachhangId)
        {
            List<int> arr = db.NguoiDiChoOnline.Where(m => m.Online == true && m.Refuse != donhangId && m.Id != khachhangId).Select(m => m.Id).ToList();
            List<double> list = new List<double>();
            double d = 0;
            double result = 0;
            double[,] arr2 = new double[arr.Count(), 2];
            double min = Double.MaxValue;
            double arrmin = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                d = arr[i];
                var nguoidicho = db.NguoiDiChoOnline.Single(a => a.Id == d);
                result = CalculateDistance.DistanceFrom(x, y, nguoidicho.X, nguoidicho.Y);
                arr2[i, 0] = arr[i];
                arr2[i, 1] = result;
            }
            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr2[i, 1] < min)
                {
                    min = arr2[i, 1];
                    arrmin = arr2[i, 0];
                }
            }
            var nguoidichothichhop = db.NguoiDiCho.SingleOrDefault(u => u.Id == arrmin);
            Common.SendNotification.SendNotifications(noidung,tieude,nguoidichothichhop.Id);
            string result1 = "Người đi chợ thích hợp là: "+nguoidichothichhop.Ten;
            return result1;
        }

    }
}