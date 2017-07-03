using Couchbase.Linq.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Messages
{
    [DocumentTypeFilter("MessageTemplate")]
    public class MessageTemplate: EwDocument
    {
        public MessageTemplate() : base("MessageTemplate")
        {
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public string BccEmailAddresses { get; set; }
        public bool IsActive { get; set; }
        public bool HasAttachedFile { get; set; }

        public string EmailAccountId { get; set; }
        public string EmailAccountAddress { get; set; }
    }

    

}
