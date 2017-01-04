using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.gogs_wrapper.Models
{
    public class Repository
    {
        public string Url { get; set; }
        public string FullName { get; set; }
        public string Private { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
