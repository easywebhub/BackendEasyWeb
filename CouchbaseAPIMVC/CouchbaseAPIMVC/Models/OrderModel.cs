using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouchbaseAPIMVC.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            Type = _type;
        }
        private static readonly string _type = "Order";

        public string Id
        {
            get
            {
                return Guid.NewGuid().ToString();
            } 
            set{}
        }
        public string ProductId { get; set; }
        public float Price  { get; set; }

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Type { get; private set; }
        public string Status { get; set; }
    }
}