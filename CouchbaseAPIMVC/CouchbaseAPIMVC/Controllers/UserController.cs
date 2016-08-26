using CouchbaseAPIMVC.Helper;
using CouchbaseAPIMVC.Models;
using CouchbaseAPIMVC.Service;
using CouchbaseAPIMVC.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CouchbaseAPIMVC.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpContentResultModel<bool> InsertUser(User model)
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
                var user = CommonService.GetDocumentUser(model);
              

                var salt = user.PasswordSalt;
                var hash = StringUtils.GenerateSaltedHash(model.Password, salt);
                var passwordMatches = hash == user.Password;
                if (!passwordMatches)
                {
                    result.StatusCode = Globals.StatusCode.InvalidData.Code;
                    result.Message = "Login Fail!!";
                    result.Result = false;
                    result.ItemsCount = 0;

                    return result;
                }
              
    
                result.Data = user;
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

    }
}
