using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CouchbaseAPIMVC.Helper;
using Newtonsoft.Json;

namespace CouchbaseAPIMVC.Models
{
    public class Order : IObject
    {
        public Order()
        {
            Type = _type;
            Id = Guid.NewGuid().ToString();
            Ngaydat = DateTime.Now;
        }
        private static readonly string _type = "Order";

        public string Id { get; set; }




        public Customer Customer { get; set; }
        public string Type { get; private set; }

        public string Status { get; set; }
        public DateTime Ngaydat { get; set; }

        public Employee Employee { get; set; }
        public Company Company { get; set; }
        public List<OrderDetail> ListOrderDetails { get; set; }

        public float DiscountTotal
        {
            get { return ListOrderDetails.Sum(x => x.Discount); }
        }
        public float MoneyTotal
        {
            get { return ListOrderDetails.Sum(x => x.Price * x.Amount); }
        }
        public string DiscountDesc
        {
            get { return String.Join(",", ListOrderDetails.Select(x => x.DiscountDetail)); }
        }


    }

    public class OrderDetail
    {


        public string ProductId { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }

        public int Amount { get; set; }
        public float Discount { get; set; }
        public string DiscountDetail { get; set; }

    }
    public class DangkyModel
    {


        public string FullName { get; set; }

        public string Phone { get; set; }


        public string Email { get; set; }

        public string Address { get; set; }


        public string Content { get; set; }


    }
}