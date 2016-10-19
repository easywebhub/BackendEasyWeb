using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using CouchbaseAPIMVC.Helper;
using CouchbaseAPIMVC.Models;
using CouchbaseAPIMVC.Service;
using CouchbaseAPIMVC.Storage;
using Newtonsoft.Json.Linq;


namespace CouchbaseAPIMVC.Controllers
{
    public class OrdersController : ApiController
    {
        public IEnumerable<OrderModel> GetListCustomers()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var rs = jss.Deserialize<List<OrderModel>>(DataProvider.FakeDb());
            return rs;
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<bool> InsertOrder(Order model)
        {

            var result = new HttpContentResultModel<bool>();
            if (ModelState.IsValid)
            {
                try
                {

                    if (CouchbaseStorageHelper.Instance.Exists("profile::" + model, "beer-sample"))
                    {
                        throw new Exception("Order already Exists!");
                    }
                    var rs = CouchbaseStorageHelper.Instance.Upsert(model.OrderId, model, "beer-sample");
                   // CommonService.SendMail(model);
                    // CommonService.SendMail(model);
                    if (!rs.Success || rs.Exception != null)
                    {
                        throw new Exception("could not save user to Couchbase");
                    }

                    result.Data = true;
                    result.StatusCode = Globals.StatusCode.Success.Code;
                    result.Message = Globals.StatusCode.Success.Message;
                    result.Result = true;
                    result.ItemsCount = 1;

                }
                catch (Exception ex)
                {
                    result.StatusCode = Globals.StatusCode.Error.Code;
                    result.Message = ex.Message;
                    result.Result = false;
                    result.ItemsCount = 0;


                }

            }
            else
            {
                result.StatusCode = Globals.StatusCode.InvalidData.Code;
                result.Message = Globals.StatusCode.InvalidData.Message;
                result.Result = false;
                result.ItemsCount = 0;
            }

            return result;
        }


        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<bool> InsertObject(Object model)
        {

            var result = new HttpContentResultModel<bool>();
            if (ModelState.IsValid)
            {
                try
                {

                    var rs = CouchbaseStorageHelper.Instance.Upsert("Product", model, "beer-sample");
                    // CommonService.SendMail(model);
                    if (!rs.Success || rs.Exception != null)
                    {
                        throw new Exception("could not save user to Couchbase");
                    }

                    result.Data = true;
                    result.StatusCode = Globals.StatusCode.Success.Code;
                    result.Message = Globals.StatusCode.Success.Message;
                    result.Result = true;
                    result.ItemsCount = 1;

                }
                catch (Exception ex)
                {
                    result.StatusCode = Globals.StatusCode.Error.Code;
                    result.Message = ex.Message;
                    result.Result = false;
                    result.ItemsCount = 0;


                }

            }
            else
            {
                result.StatusCode = Globals.StatusCode.InvalidData.Code;
                result.Message = Globals.StatusCode.InvalidData.Message;
                result.Result = false;
                result.ItemsCount = 0;
            }

            return result;
        }
        public HttpContentResultModel<bool> InsertObjectJson(JObject model)
        {

            var result = new HttpContentResultModel<bool>();
            try
            {

                var rs = CouchbaseStorageHelper.Instance.Upsert("Product", model, "beer-sample");

                if (!rs.Success || rs.Exception != null)
                {
                    throw new Exception("could not save user to Couchbase");
                }

                result.Data = true;
                result.StatusCode = Globals.StatusCode.Success.Code;
                result.Message = Globals.StatusCode.Success.Message;
                result.Result = true;
                result.ItemsCount = 1;

            }
            catch (Exception ex)
            {
                result.StatusCode = Globals.StatusCode.Error.Code;
                result.Message = ex.Message;
                result.Result = false;
                result.ItemsCount = 0;


            }



            return result;
        }
        //  var salt = StringUtils.CreateSalt(AppConstants.SaltSize);
        //var hash = StringUtils.GenerateSaltedHash(newUser.Password, salt);
        //newUser.Password = hash;
        //            newUser.PasswordSalt = salt;

        //var salt = user.PasswordSalt;
        //var hash = StringUtils.GenerateSaltedHash(password, salt);
        //var passwordMatches = hash == user.Password;
        public HttpContentResultModel<dynamic> GetListOrder(string siteId)
        {

            var result = new HttpContentResultModel<dynamic>();
            try
            {

                var rs = CommonService.GetListOrder(siteId);

               
                result.Data = rs;
                result.StatusCode = Globals.StatusCode.Success.Code;
                result.Message = Globals.StatusCode.Success.Message;
                result.Result = true;
                result.ItemsCount = rs.Count;

            }
            catch (Exception ex)
            {
                result.StatusCode = Globals.StatusCode.Error.Code;
                result.Message = ex.Message;
                result.Result = false;
                result.ItemsCount = 0;


            }



            return result;
        }
        public HttpContentResultModel<bool> InsertSite(Site model)
        {

            var result = new HttpContentResultModel<bool>();
            try
            {

                var rs = CouchbaseStorageHelper.Instance.Upsert(model.SiteId, model, "beer-sample");

                if (!rs.Success || rs.Exception != null)
                {
                    throw new Exception("could not save user to Couchbase");
                }

                result.Data = true;
                result.StatusCode = Globals.StatusCode.Success.Code;
                result.Message = Globals.StatusCode.Success.Message;
                result.Result = true;
                result.ItemsCount = 1;

            }
            catch (Exception ex)
            {
                result.StatusCode = Globals.StatusCode.Error.Code;
                result.Message = ex.Message;
                result.Result = false;
                result.ItemsCount = 0;


            }



            return result;
        }
    }
}
