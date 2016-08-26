using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using CouchbaseAPIMVC.Models;

namespace CouchbaseAPIMVC.Controllers
{
    public class CustomersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CustomerModel> Get()
        {
            return GetListCustomers();
            //JavaScriptSerializer jss = new JavaScriptSerializer();
           // var rs = jss.Deserialize<List<CustomerModel>>(FakeDb());
           // return rs;
        }
       
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

       
         private IEnumerable<CustomerModel> GetListCustomers()
         {
             JavaScriptSerializer jss = new JavaScriptSerializer();
             var rs = jss.Deserialize<List<CustomerModel>>(DataProvider.FakeDb());
             return rs;
         }
         
    }

}