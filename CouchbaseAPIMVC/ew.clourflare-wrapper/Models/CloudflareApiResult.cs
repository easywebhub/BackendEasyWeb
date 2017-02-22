using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.cloudflare_wrapper.Models
{
    public class CloudflareApiResult<T>
    {
        public bool success { get; set; }
        public List<object> errors { get; set; }
        public List<object> messages { get; set; }
        public T result { get; set; }
    }

    public class CloudflareError
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
