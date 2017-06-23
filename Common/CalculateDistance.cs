using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMarket.Common
{
    public static class CalculateDistance
    {
       
        public static double DistanceFrom(double p1latitude, double p1longitude,
                                          double p2latitude, double p2longitude)
        {
            var R = 6378137;
            var dLat = Deg2Rad(p1latitude - p2latitude);
            var dLong = Deg2Rad(p1longitude - p2longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(Deg2Rad(p1latitude)) * Math.Cos(Deg2Rad(p2latitude)) *
              Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d; 
        }        
        private static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

    }
}