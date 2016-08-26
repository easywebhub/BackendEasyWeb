using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouchbaseAPIMVC.Helper
{
    public class DataDictionary
    {
        public  class OrderStatus
        {
            public const string New = "Đơn hàng mới";
            public const string Huy = "Đã Hủy";
            public const string Processing = "Đang xử lý";
            public const string Success = "Thành công";
        }

    }
}