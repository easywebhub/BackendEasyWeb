using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Users
{
   
    [DocumentTypeFilter("Account")]
    public class Account : ewDocument
    {
        public Account() : base("Account")
        {
        }

        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Status { get; set; }
        public AccountInfo Info { get; set; }
        public List<WebsiteIdentity> Websites { get; set; }
       
    }

    public class AccountIdentity
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
    }

    public class AccountInfo
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

    }
}
