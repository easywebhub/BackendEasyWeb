using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Messages
{
    [DocumentTypeFilter("EmailAccount")]
    public class EmailAccount : EwDocument
    {
        public string EmailAddress { get; set; }
        public string EmailDisplayName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }

        public EmailAccount() : base("EmailAccount")
        {   
        }
    }
}
