using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.cloudflare_wrapper.Models
{
    public class UpdateDNSRecordDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        //public int TTL { get; set; }
        //public bool Proxied { get; set; }

    }
}
