using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CouchbaseAPIMVC.Helper;
using CouchbaseAPIMVC.Service;
using Newtonsoft.Json;

namespace CouchbaseAPIMVC.Models
{
    public class UserVm
    {
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public Info Info { get; set; }
        public List<Website> ListWebsite { get; set; }

        public UserVm(User user, List<Website> websites)
        {

            AccountId = user.AccountId;
            AccountType = user.AccountType;
            Status = user.Status;
            Info = user.Info;
            if (websites != null)
            {
                ListWebsite = websites.Select(c => HideInfo(c)).ToList();
            }
            
        }

        public Website HideInfo(Website website)
        {
            var newWeb = website;
            //  var listAccount = website.Accounts.Where(x => x.AccountId.Select(c=>c.ontains(accountId)).ToList();
            var listAccount = website.Accounts.Where(x => x.AccountId.Contains(AccountId)).ToList();
            newWeb.Accounts = new List<Account>();
            newWeb.Accounts.AddRange(listAccount.ToList());
            return newWeb;
        }
    }
    public class UserService
    {
        private User _user;
        private List<Website> _website;
        private WebsiteService _services = new WebsiteService();

        public UserVm UserLogin(string userName, string password)
        {
            // get value from db , then assign to _user, _website
            if (!GetUserByName(userName, password))
            {
                return null; // check
            }
            if (_user.Websites == null)
            {
              _user.Websites = new List<WebsiteId>();
            }
            GetWebsite();
            return new UserVm(_user, _website);
        }

        public UserVm GetUser(string userId)
        {
            LoadUserById(userId);
            GetWebsite();
            return new UserVm(_user, _website);
        }

        private bool GetUserByName(string userName,string passWord)
        {
            var user = CommonService.GetDocumentUser(userName);
            if (user != null)
            {
                var salt = user.PasswordSalt;
                var hash = StringUtils.GenerateSaltedHash(passWord, salt);
                var passwordMatches = hash == user.Password;
                if (!passwordMatches)
                {

                    return false;
                }

                _user = user;
                return true;
            }
            else
            {
                return false;
            }
            
          
            
        }

        private bool LoadUserById(string userId)
        {
            _user = new User();
            return true;
        }

        private bool GetWebsite()
        {
            if (_user == null || _user.AccountId == "")
                return false;
         
            _website = _services.GetWebsitesOfUser(_user.Websites.Select(x=>x.Id).ToList());
            return true;
        }
    }

    public class WebsiteService
    {
        public List<Website> GetWebsitesOfUser(List<string> listWebsite)
        {
            
            return CommonService.GetDocumentWebsiteId(listWebsite);
        }

        public bool UpdateWebsite(Website website)
        {
            return true;
        }
    }

    public class User
    {
        public User()
        {
            AccountId = Guid.NewGuid().ToString();
        }
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Status { get; set; }
        public Info Info { get; set; }
        public List<WebsiteId> Websites { get; set; }
        public User(UserViewModel user)
        {
            AccountId = !string.IsNullOrEmpty(user.AccountId)? user.AccountId: Guid.NewGuid().ToString();
            AccountType = user.AccountType;
            UserName = user.UserName;
            Password = user.Password;
            PasswordSalt = user.PasswordSalt;
            Status = user.Status;
            Info = user.Info;
            if (user.Websites != null && user.Websites.Count > 0)
            {
                Websites = user.Websites.Select(x => new WebsiteId(x)).ToList();
            }
           
        }



    }

    public class SignInVM
    {
        private AccountModel _account;

        public string AccountId
        {
            get { return _account.ToString(); }
            
        }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }

        public List<WebsiteId> Websites { get; set; }
        
    }

    public class AccountModel
    {
        
    }

    public class WebsiteModel
    {
        
    }

    public class UserViewModel
    {
        
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Status { get; set; }
        public Info Info { get; set; }
        public List<Website> Websites { get; set; }

      

    }
    public class UserModel
    {

        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public Info Info { get; set; }
        public List<Website> Websites { get; set; }

        public UserModel(User user,List<Website> websites )
        {
            AccountId = user.AccountId;
            AccountType = user.AccountType;
            UserName = user.UserName;
            Status = user.Status;
            Info = user.Info;
            Websites = websites;
        }



    }
    public class Info
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
      
    }

    public static class Factory
    {
        public static Website CreateWebSite()
        {
            return new Website() { Id = Guid.NewGuid().ToString(), Type = "Website"};
        }
    }

    public class Website
    {
        //public Website()
        //{
            
        //        Id = Guid.NewGuid().ToString();
        //        Type = "Website";
           
           
        //}
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }// client push id
        public string Name { get; set; }//client
        public string DisplayName { get; set; }//client
      //  public List<string> AccessLevel { get; set; } // Server gán: tham khao link https://github.com/easywebhub/BackendEasyWeb/issues/2
        public string Url { get; set; }
        public List<Stagging> Stagging { get; set; }
        public List<Production> Production { get; set; }
        public string Type { get; set; }

        public void InitAccesslevel()
        {
            foreach (var data in Accounts)
            {
                data.InitAccesslevel();
            }
        }


    }
    public class WebsiteId
    {
    
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public WebsiteId(Website website)
        {
            Id = website.Id;
            DisplayName = website. DisplayName;
        }
        public WebsiteId() { }
    }

    public class Account
    {
      //  [JsonProperty("accountId")]
        public string AccountId { get; set; }
      //  [JsonProperty("accessLevel")]
        public  List<string> AccessLevel {
            get
            {
             
                return _accessLevel;
            } set { _accessLevel = value; } }
       
        private List<string> _accessLevel = new List<string>();
        public Account()
        {
            //   AccessLevel = Globals.AccessLevel.CreateWebsite;
            


        }

        public void InitAccesslevel()
        {
            if (_accessLevel.Count == 0)
            {
                _accessLevel = Globals.AccessLevel.CreateWebsite;

            }
        }
        public Account(User user, List<string> accessLevel)
        {
            AccountId = user.AccountId;
            AccessLevel = accessLevel.Distinct().ToList();
        }
    }
    public class Stagging
    {
       
        public string Name { get; set; }
        public string HostingFee { get; set; }
        public string Url { get; set; }
        public string Git { get; set; }

    }
    public class Production
    {

        public string Name { get; set; }
        public string HostingFee { get; set; }
        public string Url { get; set; }
        public string Git { get; set; }

    }

}