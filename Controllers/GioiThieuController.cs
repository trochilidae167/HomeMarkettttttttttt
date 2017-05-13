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
using System.Text;
using System.IO;

namespace HomeMarket.Controllers
{
    public class GioiThieuController : Controller
    {
        private HomeMarketDbContext db = new HomeMarketDbContext();

        // GET: /GioiThieu/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var gioithieu = from s in db.GioiThieu select s;

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
                gioithieu = gioithieu.Where(s => s.Ten.Contains(searchString));
            }

            //Sort: AttributeSort là thuộc tính để sắp xếp, sẽ đi 1 căp AttributeSort và AttributeSort_desc,
            // có thể có nhiều hơn 1 thuộc tính có thể sắp xếp => cần thay đổi cho phù hợp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Ten = sortOrder == "Ten" ? "Ten_desc" : "Ten";
            ViewBag.NgayTao = sortOrder == "NgayTao" ? "NgayTao_desc" : "NgayTao";
            switch (sortOrder)
            {
                case "Ten":
                    gioithieu = gioithieu.OrderBy(s => s.Ten);
                    break;
                case "Ten_desc":
                    gioithieu = gioithieu.OrderByDescending(s => s.Ten);
                    break;
                case "NgayTao":
                    gioithieu = gioithieu.OrderBy(s => s.NgayTao);
                    break;
                default:
                    gioithieu = gioithieu.OrderByDescending(s => s.NgayTao);
                    break;
            }

            //Pagination
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(gioithieu.ToPagedList(pageNumber, pageSize));

        }//End Index Actions

        // GET: /GioiThieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieu.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // GET: /GioiThieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GioiThieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ten,NoiDung,NgayTao,NguoiSuDung,KhachHang,NguoiDiCho")] GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.GioiThieu.Add(gioiThieu);
                    db.SaveChanges();
                    string applicationID = "AIzaSyC6NjtiK9c5C7x88i5hP6SfPHA4LqZpsiI";
                    string SENDER_ID = "homemarket-167";
                    //lấy danh sách Registration Id
                    if (gioiThieu.KhachHang == true)
                    {
                        string[] arrRegId = db.KhachHang.Where(c => c.NguoiDiCho == false).Select(c => c.RegistrationId).ToArray();
                        string noidung = gioiThieu.NoiDung;
                        WebRequest tRequest;
                        //thiết lập GCM send
                        tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                        tRequest.Method = "POST";
                        tRequest.UseDefaultCredentials = true; tRequest.PreAuthenticate = true;

                        tRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

                        //định dạng JSON
                        tRequest.ContentType = "application/json";
                        //tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                        string RegArr = string.Empty;

                        RegArr = string.Join("\",\"", arrRegId);
                        string postData = "{ \"registration_ids\": [ \"" + RegArr + "\" ],\"data\": {\"message\": \"" + noidung + "\",\"collapse_key\":\"" + noidung + "\"}}";

                        Console.WriteLine(postData);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                        tRequest.ContentLength = byteArray.Length;

                        Stream dataStream = tRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();

                        WebResponse tResponse = tRequest.GetResponse();

                        dataStream = tResponse.GetResponseStream();

                        StreamReader tReader = new StreamReader(dataStream);

                        String sResponseFromServer = tReader.ReadToEnd();

                        string ketqua = sResponseFromServer; //Lấy thông báo kết quả từ GCM server.
                        tReader.Close();
                        dataStream.Close();
                        tResponse.Close();
                        Response.Write(@"<script language='javascript'>alert('Tui đã nói bạn đừng test mà....\nduythanhcse@gmail.com')</script>");
                    }
                }
                catch (Exception ex)
                {
                    //Response.Write(ex.ToString());
                    string msgError = ex.ToString();
                    Response.Write(@"<script language='javascript'>alert('" + msgError + "')</script>");
                }
                return RedirectToAction("Index");
        }

            return View(gioiThieu);
    }

    // GET: /GioiThieu/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        GioiThieu gioiThieu = db.GioiThieu.Find(id);
        if (gioiThieu == null)
        {
            return HttpNotFound();
        }
        return View(gioiThieu);
    }

    // POST: /GioiThieu/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Ten,NoiDung,NgayTao,NguoiSuDung,KhachHang,NguoiDiCho")] GioiThieu gioiThieu)
    {
        if (ModelState.IsValid)
        {
            db.Entry(gioiThieu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(gioiThieu);
    }

    // GET: /GioiThieu/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        GioiThieu gioiThieu = db.GioiThieu.Find(id);
        if (gioiThieu == null)
        {
            return HttpNotFound();
        }
        return View(gioiThieu);
    }

    // POST: /GioiThieu/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        GioiThieu gioiThieu = db.GioiThieu.Find(id);
        db.GioiThieu.Remove(gioiThieu);
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
