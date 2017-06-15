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
    public class LoginAPIController : ApiController
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult Login(KhachHang khachHang)
        {
            var result = db.KhachHang.SingleOrDefault(x => x.UserName == khachHang.UserName);
            
            db.Entry(result).State = EntityState.Modified;
            if (result==null)
            {
                return Json("0");
            }
            else
            {
                if (result.Password == Encryptor.MD5Hash(khachHang.Password))
                {
                    result.RegistrationId = khachHang.RegistrationId;
                    db.SaveChanges();
                    return Json("1");                    
                }
                    
                
                else
                    return Json("-1");
            }
        }
    }
}
