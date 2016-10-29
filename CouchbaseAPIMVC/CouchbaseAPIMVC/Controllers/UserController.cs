using CouchbaseAPIMVC.Helper;
using CouchbaseAPIMVC.Models;
using CouchbaseAPIMVC.Service;
using CouchbaseAPIMVC.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Couchbase.Management;

namespace CouchbaseAPIMVC.Controllers
{

    public class UserController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<bool> InsertUser(UserViewModel model)
        {

            var result = new HttpContentResultModel<bool>();

            try
            {
                var check = CommonService.ChecktUser(model.UserName);
                if (check != null)
                {
                    result.Data = false;
                    result.StatusCode = Globals.StatusCode.DataConflict.Code;
                    result.Message = Globals.StatusCode.DataConflict.Message;
                    result.Result = false;
                    result.ItemsCount = 1;
                    return result;
                }
                var salt = StringUtils.CreateSalt(24);
                var hash = StringUtils.GenerateSaltedHash(model.Password, salt);
                model.Password = hash;
                model.PasswordSalt = salt;
                
                //var salt = user.PasswordSalt;
                //var hash = StringUtils.GenerateSaltedHash(password, salt);
                //var passwordMatches = hash == user.Password;
                var user = new User(model);
              
                var rs = CouchbaseStorageHelper.Instance.Upsert(user.AccountId, user, "beer-sample");
                //diêu39
               // var websites = model.ListWebsite;
             //   NLog.LogManager.GetCurrentClassLogger().Debug("SoluongWs:----->{0}", websites.Count);
                
                //foreach (var data in websites)
                //{
                //    NLog.LogManager.GetCurrentClassLogger().Debug("SoluongWs:----->{0}", data.DisplayName);
                //   data.Accounts = data.Accounts.Select(x => new Account(user, x.AccessLevel)).ToList();
                //   CouchbaseStorageHelper.Instance.Upsert(data.Id, data, "beer-sample");
                //}
              
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




            return result;
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<bool> UpdateUser(User model)
        {

            var result = new HttpContentResultModel<bool>();

            try
            {

                var salt = StringUtils.CreateSalt(24);
                var hash = StringUtils.GenerateSaltedHash(model.Password, salt);
                model.Password = hash;
                model.PasswordSalt = salt;

                //var salt = user.PasswordSalt;
                //var hash = StringUtils.GenerateSaltedHash(password, salt);
                //var passwordMatches = hash == user.Password;
              
                var websites = model.Websites;
                var rs = CouchbaseStorageHelper.Instance.Upsert(model.AccountId, model, "beer-sample");
                
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




            return result;
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<dynamic> Logon(User model)
        {
            var result = new HttpContentResultModel<dynamic>();
          
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new UserService();
                    var userViewModel = service.UserLogin(model.UserName, model.Password);




                    result.Data = userViewModel;
                    result.StatusCode = Globals.StatusCode.Success.Code;
                    result.Message = Globals.StatusCode.Success.Message;
                    result.Result = true;
                    result.ItemsCount = 1;
                }
               
                // var user = CommonService.GetDocumentUser(model);
             

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

        //public bool ValidateUser(string userName, string password, int maxInvalidPasswordAttempts)
        //{
        //    userName = StringUtils.SafePlainText(userName);
        //    password = StringUtils.SafePlainText(password);

        //    LastLoginStatus = LoginAttemptStatus.LoginSuccessful;

        //    var user = GetUser(userName);

        //    if (user == null)
        //    {
        //        LastLoginStatus = LoginAttemptStatus.UserNotFound;
        //        return false;
        //    }

        //    if (user.IsBanned)
        //    {
        //        LastLoginStatus = LoginAttemptStatus.Banned;
        //        return false;
        //    }

        //    if (user.IsLockedOut)
        //    {
        //        LastLoginStatus = LoginAttemptStatus.UserLockedOut;
        //        return false;
        //    }

        //    if (!user.IsApproved)
        //    {
        //        LastLoginStatus = LoginAttemptStatus.UserNotApproved;
        //        return false;
        //    }

        //    var allowedPasswordAttempts = maxInvalidPasswordAttempts;
        //    if (user.FailedPasswordAttemptCount >= allowedPasswordAttempts)
        //    {
        //        LastLoginStatus = LoginAttemptStatus.PasswordAttemptsExceeded;
        //        return false;
        //    }

        //    var salt = user.PasswordSalt;
        //    var hash = StringUtils.GenerateSaltedHash(password, salt);
        //    var passwordMatches = hash == user.Password;

        //    user.FailedPasswordAttemptCount = passwordMatches ? 0 : user.FailedPasswordAttemptCount + 1;

        //    if (user.FailedPasswordAttemptCount >= allowedPasswordAttempts)
        //    {
        //        user.IsLockedOut = true;
        //        user.LastLockoutDate = DateTime.UtcNow;
        //    }

        //    if (!passwordMatches)
        //    {
        //        LastLoginStatus = LoginAttemptStatus.PasswordIncorrect;
        //        return false;
        //    }

        //    return LastLoginStatus == LoginAttemptStatus.LoginSuccessful;
        //}

        private bool addWebsitetoAccount(string userId, string websiteId, string websiteDisplayName)
        {
            var user = CommonService.GetUserById(userId);
            user.Websites.Add(new WebsiteId() { Id = websiteId, DisplayName =  websiteDisplayName});
            CouchbaseStorageHelper.Instance.Upsert(user.AccountId, user, "beer-sample");
            return true;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<bool> CreateWebsite(Website model)
        {

           // model.Accounts.FirstOrDefault().AccessLevel
            var result = new HttpContentResultModel<bool>();

            try
            {

                if (model.Id == null) 
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.Type = "Website";
                    

                }
                model.InitAccesslevel();
                  var rs = CouchbaseStorageHelper.Instance.Upsert(model.Id, model, "beer-sample");
                var user = CommonService.GetListUpdateDocumentUser(model.Accounts);
                foreach (var data in user)
                {
                    if (data.Websites == null)
                    {
                        data.Websites = new List<WebsiteId>();
                    }
                    data.Websites.Add(new WebsiteId { Id = model.Id, DisplayName = model.DisplayName });
                    CouchbaseStorageHelper.Instance.Upsert(data.AccountId, data, "beer-sample");
                }
                // Bỏ cai a  Bao chỉ support 1 user
                //addWebsitetoAccount(model.Accounts.First().AccountId, model.Id, model.DisplayName)
                //;

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




            return result;
        }
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<dynamic> GetListWebsite()
        {

            var result = new HttpContentResultModel<dynamic>();

            try
            {


                
                //var user = CouchbaseStorageHelper.Instance.Get(data.AccountId);

                var rs = CommonService.GetDocumentAllWebsite();
               

         
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
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<dynamic> GetListUser()
        {

            var result = new HttpContentResultModel<dynamic>();

            try
            {



                //var user = CouchbaseStorageHelper.Instance.Get(data.AccountId);

                var rs = CommonService.GetDocumentAllUser();



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
    }
}


