using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouchbaseAPIMVC.Models
{
    public class Employee : IObject
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
    public class Company : IObject
    {
        public Company()
        {
            Type = _type;
        }

        private static readonly string _type = "Organization";

        public string Id { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Type { get; private set; }
        public string Status { get; set; }
    }

}