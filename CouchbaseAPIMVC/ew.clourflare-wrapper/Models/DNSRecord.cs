using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.cloudflare_wrapper.Models
{
    public class DNSRecord
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public bool proxiable { get; set; }
        public bool proxied { get; set; }
        public int ttl { get; set; }
        public bool locked { get; set; }
        public string zone_id { get; set; }
        public string zone_name { get; set; }
        public string modified_on { get; set; }
        public string created_on { get; set; }
    }


}
