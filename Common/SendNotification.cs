using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeMarket.Models;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;

namespace HomeMarket.Common
{
    public class SendNotification
    {
        private static HomeMarketDbContext db = new HomeMarketDbContext();
        public static string SendNotifications(string noidung, string tieude, int RegId)
        {
            string result = "";
            string applicationID = "AAAAI2A8sWk:APA91bHglfbnhgC7dlLhDvyMxd4G8zaHFfY7ye6_dly1kF7pHqidsiNgDbc8VV8VEwiZBCqIUfuAVFrRZH-b1LJ9M_6xbkhw7SlY4af36Qn0An3PxGmgu5oEAjP-j8bMZxmUAyMbsyY9";
            string SENDER_ID = "151938445673";
            //lấy danh sách Registration Id
            string[] arrRegId = db.KhachHang.Where(c => c.Id == RegId).Select(c => c.RegistrationId).ToArray();
            string RegArr = string.Empty;

            RegArr = string.Join("\",\"", arrRegId);
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

            tRequest.Method = "post";

            tRequest.ContentType = "application/json";

            var data = new

            {

                to = RegArr, // RegArr là đoạn mã riêng dành cho mỗi Client

                notification = new

                {

                    body = noidung,// nội dung của thông báo

                    title = tieude,// tiêu đề của thông báo
                }
            };

            var serializer = new JavaScriptSerializer();

            var json = serializer.Serialize(data);

            Byte[] byteArray = Encoding.UTF8.GetBytes(json);

            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            tRequest.ContentLength = byteArray.Length;


            using (Stream dataStream = tRequest.GetRequestStream())
            {

                dataStream.Write(byteArray, 0, byteArray.Length);


                using (WebResponse tResponse = tRequest.GetResponse())
                {

                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {

                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {

                            String sResponseFromServer = tReader.ReadToEnd();

                            string str = sResponseFromServer;
                        }
                    }
                }
            }

            return result;
        }
    }
}
