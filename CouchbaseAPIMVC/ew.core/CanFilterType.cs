using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core
{
    public class ewDocument
    {
        [Key]
        public string Id { get; set; }
        public string Type { get; set; }
        
        public ewDocument(string type)
        {
            Type = type;
        }
    }
}
