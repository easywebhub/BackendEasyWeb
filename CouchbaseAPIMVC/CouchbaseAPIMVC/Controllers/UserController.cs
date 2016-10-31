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
        [Route("api-user/InsertUser")]
        [Route("auth/signup")]
        public HttpContentResultModel<bool> InsertUser(UserViewModel model)
        {

            var result = new HttpContentResultModel<bool>();

            try
            {
                var check = CommonService.CheckUser(model.UserName);
                if (check != null)
                {
                    result.Data = false;
                    result.StatusCode = Globals.StatusCode.DataConflict.Code;
                    result.Message = "Tên tài khoản đã tồn tại. Vui lòng sử dụng tên khác.";
                    result.Result = false;
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
            }
            return result;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api-user/Logon")]
        [Route("auth/signin")]
        public HttpContentResultModel<dynamic> Logon(User model)
        {
            var result = new HttpContentResultModel<dynamic>();

            try
            {
                if (ModelState.IsValid)
                {
                    var service = new UserService();
                    var userViewModel = service.UserLogin(model.UserName, model.Password);
                    
                    result.StatusCode = service.Status;
                    result.Message = userViewModel != null ? "Thành công" : "Tên đăng nhập hoặc mật khẩu không chính xác.";
                    result.Result = userViewModel != null;
                    if (result.Result)
                    {
                        result.ItemsCount = 1;
                        result.Data = userViewModel;
                    }
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

        //[HttpPost]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //[Route("api-user/UpdateUser")]
        //[Route("user/update-profile")]
        //public HttpContentResultModel<bool> UpdateUser(UserViewModel model)
        //{
        //    var result = new HttpContentResultModel<bool>();
        //    try
        //    {
        //        var service = new UserService();
        //        var user = service.GetUser(model.AccountId);
        //        if (user != null)
        //        {
        //            user.Info = model.Info;
        //            CouchbaseStorageHelper.Instance.Upsert(model.AccountId, user, "beer-sample");
        //            result.Data = true;
        //            result.StatusCode = "Success";
        //            result.Message = Globals.StatusCode.Success.Message;
        //            result.Result = true;
        //            result.ItemsCount = 1;
        //        }else
        //        {
        //            result.StatusCode = "User_NotFound";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.StatusCode = Globals.StatusCode.Error.Code;
        //        result.Message = ex.Message;
        //        result.Result = false;
        //        result.ItemsCount = 0;
        //    }
        //    return result;
        //}



        //[HttpPost]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //[Route("user/change-password")]
        //public HttpContentResultModel<bool> DeleteUser(UserViewModel model)
        //{
        //    var result = new HttpContentResultModel<bool>();
        //    try
        //    {
        //        var service = new UserService();
        //        var user = service.GetUser(model.AccountId);
        //        if (user != null)
        //        {
        //            user.Info = model.Info;
        //        }
        //        var rs = CouchbaseStorageHelper.Instance.Upsert(model.AccountId, user, "beer-sample");

        //        // CommonService.SendMail(model);
        //        if (!rs.Success || rs.Exception != null)
        //        {
        //            throw new Exception("could not save user to Couchbase");
        //        }

        //        result.Data = true;
        //        result.StatusCode = Globals.StatusCode.Success.Code;
        //        result.Message = Globals.StatusCode.Success.Message;
        //        result.Result = true;
        //        result.ItemsCount = 1;

        //    }
        //    catch (Exception ex)
        //    {
        //        result.StatusCode = Globals.StatusCode.Error.Code;
        //        result.Message = ex.Message;
        //        result.Result = false;
        //        result.ItemsCount = 0;
        //    }
        //    return result;
        //}


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

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api-user/AddWebsitetoAccount")]
        [Route("website/add-account")]
        public HttpContentResultModel AddWebsitetoAccount(AddWebsiteToAccountDto dto)
        {
            var result = new HttpContentResultModel();
            if (ModelState.IsValid)
            {
                var user = CommonService.GetUserById(dto.AccountId);
                if (user != null)
                {
                    //var uweb = user.Websites.FirstOrDefault(x => x.Id == dto.WebsiteId);
                    if (user.Websites == null) user.Websites = new List<WebsiteId>();
                    user.Websites.Add(new WebsiteId() { Id = dto.WebsiteId, DisplayName = dto.WebsiteDisplayName });
                    var website = CommonService.GetWebsiteById(dto.WebsiteId);
                    if (website == null)
                    {
                        result.StatusCode = "Website_NotFound";
                        result.Message = "Không thành công!";
                        goto End;
                    }
                    if (website.Accounts == null) website.Accounts = new List<Account>();
                    website.Accounts.Add(new Account() { AccountId = user.AccountId, AccessLevel = dto.AccessLevel });
                    CouchbaseStorageHelper.Instance.Upsert(user.AccountId, user, "beer-sample");
                    CouchbaseStorageHelper.Instance.Upsert(website.Id, website, "beer-sample");

                    result.Result = true;
                    result.ItemsCount = 1;
                    result.Message = "Thành công!";

                    return result;
                }else
                {
                    result.StatusCode = "User_NotFound";
                    result.Message = "Không thành công!";
                }
                
            }
            else
            {
                result.StatusCode = "InvalidData";
            }
            End:
            return result;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api-user/CreateWebsite")]
        [Route("website/addnew")]
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
        [Route("api-user/GetListWebsite")]
        [Route("website/all")]
        public HttpContentResultModel<dynamic> GetListWebsite()
        {
            var result = new HttpContentResultModel<dynamic>();
            try
            {
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
        [Route("api-user/GetListUser")]
        [Route("account/all")]
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


