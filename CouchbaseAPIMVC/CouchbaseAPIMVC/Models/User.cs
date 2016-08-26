using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Status { get; set; }
        public Info Info { get; set; }
        public List<Website> Websites { get; set; }
       


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
            Id = "easywebhub-" + Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<string> AccessLevel { get; set; }
        public string Url { get; set; }
        public List<Stagging> Stagging { get; set; }
        public List<Production> Production { get; set; }

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