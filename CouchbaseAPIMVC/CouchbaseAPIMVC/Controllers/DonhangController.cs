
using System.Linq;

using System.Web.Mvc;
using CouchbaseAPIMVC.Helper;
using CouchbaseAPIMVC.Models;
using CouchbaseAPIMVC.Service;
using Microsoft.AspNet.Identity;

namespace CouchbaseAPIMVC.Controllers
{
    public class DonhangController : Controller
    {
        //
        // GET: /Donhang/
         //[Route("Don-hang")]
        [Route("Don-hang-MVC")]
        public ActionResult Index()
        {

            var order = CommonService.GetDocumentDataOrderByCompany(User.Identity.GetUserName());
            return View(order);
        }

        //
        // GET: /Donhang/Details/5
        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Donhang/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Donhang/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Donhang/Edit/5
       // [Route("test/id")]
      //    [Route("Donhang/{id}")]
        public ActionResult Edit(string id)
        {
            ViewBag.OrderStatus = typeof(DataDictionary.OrderStatus).GetFields().Select(field => field.GetValue(typeof (DataDictionary.OrderStatus))).ToList();
            var model = CommonService.GetDocumentDataOrderbyId(id);

            return View(model);
        }

        //
        // POST: /Donhang/Edit/5
      //    [Route("Donhang/{id}")]
        [HttpPost]
        public ActionResult Edit(Order order,string status)
        {
            try
            {
                // TODO: Add update logic here

               // ViewBag.OrderStatus  = typeof (DataDictionary.OrderStatus).GetFields().ToList();
                order.OrderStatus = status;
               
            //   order.Employee = new Employee { Name = User.Identity.Name, Company = order.Company };
               // var rs = CommonService.EditOrder(order);
               

              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Donhang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Donhang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
