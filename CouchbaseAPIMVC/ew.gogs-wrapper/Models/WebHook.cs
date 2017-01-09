using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.gogs_wrapper.Models
{
    public class WebHook
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public bool Active { get; set; }
    }
}
