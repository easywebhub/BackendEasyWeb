using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.AspNet.Identity
{
   public class Customer
    {
        private static readonly string _type = "Customer_1";

        public Customer()
        {
            Type = _type;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Type { get; private set; }
    }
   public class Employee 
   {
       public Employee()
       {
           Type = _type;
           Id = Guid.NewGuid().ToString();
       }

       private static readonly string _type = "Employee";

       public string Id { get; set; }

       public string Name { get; set; }
       public string Address { get; set; }
       public Company Company { get; set; }
       public string Type { get; private set; }
       public string Status { get; set; }
   }
   public class Company 
   {
       public Company()
       {
           Type = _type;
           Id = Guid.NewGuid().ToString();
       }

       private static readonly string _type = "Organization";

       public string Id { get; set; }

       public string CompanyName { get; set; }
       public string Address { get; set; }
       public string Type { get; private set; }
       public string Status { get; set; }
   }
}
