using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CouchbaseAPIMVC.Helper;
using Newtonsoft.Json;

namespace CouchbaseAPIMVC.Models
{
    public class OrderInfo
    {
        public OrderInfo()
        {
         
            Ngaydat = DateTime.Now;
        }
    
        public string Status { get; set; }
        public DateTime Ngaydat { get; set; }

        public Employee Employee { get; set; }
        public Company Company { get; set; }
        public List<OrderDetail> ListProduct { get; set; }

        public float DiscountPrice
        {
            get { return ListProduct.Sum(x => x.Discount); }
        }
        public float TotalPrice
        {
            get { return ListProduct.Sum(x => x.Price * x.Unit); }
        }

        public float ShippingCost { get; set; }
    }

    public class OrderDetail
    {
        
        public string ProductUrl { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }

        public int Unit { get; set; }
        public float Discount { get; set; }
       

    }

    public class Order
    {
        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            OrderStatus = "New";
            Type = "Order";
        }
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public Site SiteInfo { get; set; }
        public Customer CustomerInfo { get; set; }
        public Customer ShippintInfo { get; set; }
        public  OrderInfo OrderInfo { get; set; }

        public string Type { get;  set; }

    }

    public class Site
    {
        public string SiteId { get; set; }
        public string Domain { get; set; }
        public ConfirmEmail ConfirmEmail { get; set; }
    }
    public class ConfirmEmail
    {
        public string AdminEmail { get; set; }
        public string EmailTitle { get; set; }
        public string HtmlTemplate { get; set; }
    }

    public class DangkyModel
    {


        public string FullName { get; set; }

        public string Phone { get; set; }


        public string Email { get; set; }

        public string Address { get; set; }


        public string Content { get; set; }


    }
    public class ShippintInfo
    {


        public string DisplayName { get; set; }

        public string Phone { get; set; }


        public string Email { get; set; }

        public string Address { get; set; }


        public string Sex { get; set; }


    }
}