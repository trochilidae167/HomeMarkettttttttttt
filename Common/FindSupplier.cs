using HomeMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMarket.Common
{
    public class FindSupplier
    {
        public static HomeMarketDbContext db = new HomeMarketDbContext();
        public static List<int> LookingForSupplier(double x, double y)
        {
            List<int> arr = db.NhaCungUng.Where(n=>n.Id != 0).Select(s=>s.Id).ToList();
            List<int> list = new List<int>();
            double d = 0;
            double result = 0;
            double[,] arr2 = new double[arr.Count(), 2];
            for (int i = 0; i < arr.Count(); i++)
            {
                d = arr[i];
                var ncu = db.NhaCungUng.Single(a => a.Id == d);
                result = CalculateDistance.DistanceFrom(x, y, ncu.X, ncu.Y);
                arr2[i, 0] = arr[i];
                arr2[i, 1] = result;
                if (result < 200000)
                {
                    list.Add(arr[i]);
                }
                //list.Add(arr[i]);
            }
            return list;
        }
    }
}