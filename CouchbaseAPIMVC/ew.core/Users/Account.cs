using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Users
{
   
    [DocumentTypeFilter("Account")]
    public class Account : EwDocument
    {
        public Account() : base("Account")
        {
            Info = new AccountInfo();
            Websites = new List<WebsitesAccessLevelOfAccount>();
        }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Status { get; set; }
        public AccountInfo Info { get; set; }
        public List<WebsitesAccessLevelOfAccount> Websites { get; set; }
    }

    public class WebsitesAccessLevelOfAccount
    {
        public string WebsiteId { get; set; }
        public string DisplayName { get; set; }
        public List<string> AccessLevels { get; set; }

        public WebsitesAccessLevelOfAccount(Website website)
        {
            WebsiteId = website.Id;
            DisplayName = website.DisplayName;
            AccessLevels = website.Accounts.Where(x => x.AccountId == website.Id).Select(x => x.AccessLevels).FirstOrDefault();
        }
        public WebsitesAccessLevelOfAccount() { }
    }

    public class AccountIdentity
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
    }

    public class AccountInfo
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
    }
}
