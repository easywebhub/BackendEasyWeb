using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Configurations
{
    [DocumentTypeFilter("Setting")]
    public class Setting: EwDocument
    {
        public Setting() : base("Setting")
        {
        }

        public string Name { get; set; }

        public string CodeName { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public string DefaultValue { get; set; }

        public string Value { get; set; }

        public bool IsPrivate { get; set; }
    }
}
