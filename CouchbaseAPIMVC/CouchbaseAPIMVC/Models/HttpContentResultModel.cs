using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CouchbaseAPIMVC.Models
{
    public class HttpContentResultModel
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public int ItemsCount { get; set; }

        public object Data { get; set; }

    }

    public class HttpContentResultModel<T>
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public int ItemsCount { get; set; }

        public object Data { get; set; }

    }
}