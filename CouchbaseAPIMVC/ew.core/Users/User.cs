using Couchbase.AspNet.Identity;
using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Users
{
    [DocumentTypeFilter("User")]
    public class IUser: IdentityUser
    {

        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Sex { get; set; }
        public string PersonalId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public DateTime? ActivedDate { get; set; }
        public string Address { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
    }
    
}
