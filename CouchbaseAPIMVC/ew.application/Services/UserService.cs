using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.AspNet.Identity;
using ew.core;
using Microsoft.AspNet.Identity;
using ew.core.Users;
using ew.application.Entities.Dto;

namespace ew.application.services
{
    public class UserService
    {
        private readonly ThrowableBucket _dbBucket;

        public UserService(ThrowableBucket bucket)
        {
            _dbBucket = bucket;
        }

        private UserManager<core.Users.IUser> _identityUserManager;
        public UserManager<core.Users.IUser> IdentityUserManager
        {
            get
            {
                if (_identityUserManager == null)
                {

                    _identityUserManager = new UserManager<core.Users.IUser>(new UserStore<core.Users.IUser>(_dbBucket));
                    var userValidator = _identityUserManager.UserValidator as UserValidator<core.Users.IUser>;
                    if (userValidator == null) userValidator = new UserValidator<core.Users.IUser>(_identityUserManager);
                    userValidator.AllowOnlyAlphanumericUserNames = false;
                    _identityUserManager.UserValidator = userValidator;
                    //identityUserManager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<core.Account.User>
                    //{
                    //    Subject = "Security Code",
                    //    BodyFormat = "Your security code is {0}"
                    //});
                    //new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));
                }
                return _identityUserManager;
            }
        }

        public IdentityResult RegisterUser(UserModel userModel)
        {
            var user = userModel.ToEntity(new core.Users.IUser());
            var result = IdentityUserManager.Create(user, userModel.Password);
            return result;
        }

        //public IQueryable<User> FindAll()
        //{
        //    //return IdentityUserManager
        //}
        
    }
}
