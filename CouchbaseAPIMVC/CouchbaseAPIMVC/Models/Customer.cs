using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CouchbaseAPIMVC.Models
{
    public interface IObject
    {
        string Id { get; set; }
    }

    public class Customer : IObject
    {
        public Customer()
        {
            Type = _type;
        }
        private static readonly string _type = "Customer";
        public string Id { get; set; }
        [Required(ErrorMessage = "Phải nhập Tên khách hàng")] 
        public string Name { get; set; }
     
        public string Email { get; set; }
        public string Address { get; set; }
         [Required(ErrorMessage = "Phải nhập số dt khách hàng")] 
        public string Phone { get; set; }
        public string Type { get; private set; }


    }

    public class CustomerModel 
    {
        private static readonly string _type = "CustomerModel";

        public CustomerModel()
        {
            Type = _type;
        }
        public int Id { get; set; }

        public string CustomerID { get; set; }
        public string CustomerID_OLD { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }    
      

        public string Type { get; private set; }


    }

    public class Property
    {
        public string PropertyName { get; set; }

        public string PropertyValue { get; set; }
    }
    
}