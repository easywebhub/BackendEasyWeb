using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CouchbaseAPIMVC.Models;
using Customer = Couchbase.AspNet.Identity.Customer;

namespace CouchbaseAPIMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Customer customer = new Customer
            {
                Id = "7",
                Name = "teo4",
                Age = 28,

            };
         //   ApplicationCustomer.InsertWithPersistTo(customer);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var rs = jss.Deserialize<List<CustomerModel>>(DataProvider.FakeDb());
            foreach (var item in rs)
            {
                
               // ApplicationCustomer.InsertWithPersistTo(item);
            }
            //ApplicationCustomer.InsertWithPersistTo(rs);
            NLog.LogManager.GetCurrentClassLogger().Debug(" Test Nlog");  // đã ghi log OK 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}