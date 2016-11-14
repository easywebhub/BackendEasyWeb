using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using System.Web.UI;
using Couchbase;
using Couchbase.AspNet.Identity;
using Couchbase.Core;
using Couchbase.Linq;
using CouchbaseAPIMVC.Helper;
using CouchbaseAPIMVC.Models;
using Couchbase.Linq;

using Newtonsoft.Json.Linq;



namespace CouchbaseAPIMVC.Service
{
    public class CommonService
    {
        private static IBucket _bucket;

        public static async Task<bool> InsertWithPersistTo(IObject value)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            value.Id = Guid.NewGuid().ToString();

            //   _bucket = ClusterHelper.
            var result = await _bucket.UpsertAsync(Guid.NewGuid().ToString(), value, ReplicateTo.Two);
            if (result.Success)
            {
                return true;
            }
            return false;
        }
        public static IObject GetDocument(string id)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = _bucket.GetDocument<IObject>(id);
            return result.Content;
        }

        public static async Task<bool> DeleteDocument(IObject document)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = _bucket.Remove(document.Id);
            if (result.Success)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> DeleteDocument(string id)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = _bucket.Remove(id);
            if (result.Success)
            {
                return true;
            }
            return false;
        }
        public static List<Order> GetDocumentDataOrder()
        {

         
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<Order>()
                        where b.Type == "Order"
                        select b;

            var rs = query.ToList();
           
            return rs;
            //return query.FirstOrDefault();
        }
        public static List<Order> GetDocumentDataOrderByCompany(string userName)
        {

            _bucket = ClusterHelper.GetBucket("beer-sample");
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));
            string str = "SELECT c FROM `beer-sample` as c where email ='" + userName + "'";
            
            var user = _bucket.Query<dynamic>(str);
            if (user.Rows.Count > 0)
            {
                string companyName = user.Rows[0]["c"]["employee"]["company"]["companyName"].ToString();

                var query = from b in db.Query<Order>()
                            where b.Type == "Order" //&& b.Company.CompanyName == companyName//user.Rows[0].Employee.Company.CompanyName
                            select b;

                var rs = query.ToList();
                return rs;

            }
           
            return new List<Order>();
            //return query.FirstOrDefault();
        }
        public static Order GetDocumentDataOrderbyId(string id)
        {
         

            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<Order>()
                        where b.Type == "Order" && b.OrderId == id
                        select b;

            var rs = query.ToList();

            return rs.FirstOrDefault();
            //return query.FirstOrDefault();
        }

        //public static bool InsertOrder(Order value)
        //{
        //    _bucket = ClusterHelper.GetBucket("beer-sample");
        //    value.Id = Guid.NewGuid().ToString();
        //    if (value.Status == null)
        //    {
        //        value.Status = DataDictionary.OrderStatus.New;
        //    }
        //    //   _bucket = ClusterHelper.
        //    //NullableValueTransformer==
        //    value.Customer.Id = Guid.NewGuid().ToString();
        //    var result = _bucket.InsertAsync(value.Id, value, ReplicateTo.Zero, PersistTo.Two);

        //    var order = _bucket.UpsertAsync(value.Customer.Id, value.Customer, ReplicateTo.Two);


           
        //    return true;
        //}

        //public static bool EditOrder(Order value)
        //{
        //    _bucket = ClusterHelper.GetBucket("beer-sample");
        //    if (value.Status == null)
        //    {
        //        value.Status = DataDictionary.OrderStatus.New;
        //    }
          
        //    var result = _bucket.UpsertAsync(value.Id, value, ReplicateTo.Two);
        //    if (value.Employee != null)
        //    {
        //        var emp = _bucket.UpsertAsync(value.Employee.Id, value.Employee, ReplicateTo.Two);
        //    }

        //    var order = _bucket.UpsertAsync(value.Customer.Id, value.Customer, ReplicateTo.Two);
           
        //    return true;




        //}

      /*public static  void SendMail(Order order)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("thin01nguyenvan@gmail.com", "kdbxbtsxzupqxnzx");
            string mailTemp = "/Templete/Email.htm";

            MailMessage mm = new MailMessage("thin01nguyenvan@gmail.com", order.Company.Address, "Test đặt hàng Couchbase", "Khách hàng: "
                + order.Customer.Name + ",Phone:" + order.Customer.Phone + " ,Địa chỉ:" + order.Customer.Address + " ,Sản phẩm: " + order.ProductId);
            mm.BodyEncoding = UTF8Encoding.UTF8;

          //  mm.IsBodyHtml
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
           
        }*/

        //public static  void SendMail(Order order)
        //{

        //    var mail = new MailHelper();
        //    string subject = "";
        //    string body = "";
        //    string mailTemp = "/Templete/Email.htm";
        //    string emailSend = ConfigurationManager.AppSettings["EmailSend"];
        //    string emailBcc = ConfigurationManager.AppSettings["EmailBCC"];
        //    if (mail.ReadEmailTemplate(mailTemp, ref subject, ref body))
        //    {

        //        body = body.Replace("[HoTen]", order.Customer.Name);
        //        body = body.Replace("[DienThoai]", order.Customer.Phone);
        //        body = body.Replace("[Email]", order.Customer.Email);
        //        body = body.Replace("[Address]", order.Customer.Address);
        //        body = body.Replace("[product]", order.ListOrderDetails[0].ProductId);
        //        body = body.Replace("[Amount]", order.ListOrderDetails[0].Amount.ToString());
        //        body = body.Replace("[DateCreated]", order.Ngaydat.ToString("dd/MM/yyyy hh:mm:ss"));
        //        mail.SendEmail(emailSend,
        //            emailBcc,
        //            "",
        //            subject, body);
        //    }
           
           
        //}
        public static User GetDocumentUser(string userName)
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<User>()
                        where b.AccountType == "user" && b.UserName == userName
                        select b;

            var rs = query.ToList();

            return rs.FirstOrDefault();
            //return query.FirstOrDefault();
        }
        public static User GetDocumentUserById(string id)
        {
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<User>()
                        where b.AccountType == "user" && b.AccountId == id
                        select b;

            return query.FirstOrDefault();
            //return query.FirstOrDefault();
        }

        public static User CheckUser(string userName)
        {
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));
            var query = from b in db.Query<User>()
                        where b.AccountType == "user" && b.UserName == userName
                        select b;
            var rs = query.ToList();
            return rs.FirstOrDefault();
        }

        public static User GetUserById(string userId)
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<User>()
                        where b.AccountType == "user" && b.AccountId == userId
                        select b;

            var rs = query.ToList();

            return rs.FirstOrDefault();
            //return query.FirstOrDefault();
        }

        public static Website GetWebsiteById(string id)
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<Website>()
                        where b.Type == "Website" && b.Id == id
                        select b;

            var rs = query.ToList();

            return rs.FirstOrDefault();
            //return query.FirstOrDefault();
        }


        public static List<Website> GetDocumentWebsite(string accountId)
        {

            //if(user.Websites.Count == 0) return new List<Website>();
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));
        
            var web = from b in db.Query<Website>()
                      where b.Accounts.Select(x=>x.AccountId.Contains(accountId)).Any()
                      select b;
           // List<Website> websites = web.ToList();
            return web.ToList();
            //return query.FirstOrDefault();
        }

        public static List<Website> GetDocumentWebsiteId(List<string> websites)
        {

            //if(user.Websites.Count == 0) return new List<Website>();
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var web = (from b in db.Query<Website>()
                     // where b.Accounts.Select(x => x.AccountId.Contains(accountId)).Any()
                      select b).ToList();
            List<Website> listWebsite = web.Where(x=> websites.Contains(x.Id)).ToList();
            return listWebsite.ToList();
            //return query.FirstOrDefault();
        }
        public static List<User> GetListUpdateDocumentUser(List<Account> accounts)
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));
            var listAccountId = accounts.Select(x => x.AccountId).ToList();
            var query = from b in db.Query<User>()
                        where b.AccountType == "user"// && listAccountId.Contains(b.AccountId) 
                        select b;

            var rs = query.ToList();
           var result = rs.Where(x => listAccountId.Contains(x.AccountId)).ToList();
            return result;
            //return query.FirstOrDefault();
        }
        public static List<User> GetDocumentAllUser()
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));
          
            var query = from b in db.Query<User>()
                        where b.AccountType == "user"// && listAccountId.Contains(b.AccountId) 
                        select b;

            var rs = query.ToList();
            
            return rs;
            //return query.FirstOrDefault();
        }
        public static List<Website> GetDocumentAllWebsite()
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<Website>()
                        where b.Type == "Website"// && listAccountId.Contains(b.AccountId) 
                        select b;

            var rs = query.ToList();

            return rs;
            //return query.FirstOrDefault();
        }
        // Lấy order
        public static List<Order> GetListOrder(string siteId)
        {


            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<Order>()
                        where b.Type == "Order" && b.SiteInfo.SiteId== siteId
                        select b;

            var rs = query.ToList();

            return rs;
            
        }
    }
}