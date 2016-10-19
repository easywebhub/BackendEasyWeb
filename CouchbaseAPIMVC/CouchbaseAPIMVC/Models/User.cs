using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CouchbaseAPIMVC.Helper;

namespace CouchbaseAPIMVC.Models
{
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
        public List<Websites> Websites { get; set; }
        public User(UserViewModel user)
        {
            AccountId = !string.IsNullOrEmpty(user.AccountId)? user.AccountId: Guid.NewGuid().ToString();
            AccountType = user.AccountType;
            UserName = user.UserName;
            Password = user.Password;
            PasswordSalt = user.PasswordSalt;
            Status = user.Status;
            Info = user.Info;
            Websites = user.Websites.Select(x=> new Websites(x)).ToList();
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

        public List<Websites> Websites { get; set; }
        
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
    public class Website
    {
        public Website()
        {
            Id = Guid.NewGuid().ToString();
            Type = "Website";
        }
        
        public string Id { get; set; }
       public List<Account> Accounts { get; set; }// client push id
        public string Name { get; set; }//client
        public string DisplayName { get; set; }//client
      //  public List<string> AccessLevel { get; set; } // Server gán: tham khao link https://github.com/easywebhub/BackendEasyWeb/issues/2
        public string Url { get; set; }
        public List<Stagging> Stagging { get; set; }
        public List<Production> Production { get; set; }
        public string Type { get; set; }



    }
    public class Websites
    {
    
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public Websites(Website website)
        {
            Id = website.Id;
            DisplayName = website. DisplayName;
        }
        public Websites() { }
    }
    public class Account
    {

        public string AccountId { get; set; }
        public  List<string> AccessLevel { get; set; }

        public Account()
        {

            AccessLevel = Globals.AccessLevel.CreateWebsite;

        }
        public Account(User user, List<string> accessLevel)
        {
            AccountId = user.AccountId;
            AccessLevel = accessLevel;
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