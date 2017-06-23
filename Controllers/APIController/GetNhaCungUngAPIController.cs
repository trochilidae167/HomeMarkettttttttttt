using HomeMarket.Common;
using HomeMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HomeMarket.Controllers.APIController
{
    public class GetNhaCungUngAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();
        public class KhachHangOnline
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        [HttpPost]
        public IHttpActionResult PostNhaCungUng(KhachHangOnline khachHangOnline)
        {
            List<int> list = FindSupplier.LookingForSupplier(khachHangOnline.X, khachHangOnline.Y);
            if (list != null)
            {
                var ncu = db.NhaCungUng.Where(x => list.Contains(x.Id));
                return Ok(ncu);
            }
            else
                return NotFound();
        }
    }
}
