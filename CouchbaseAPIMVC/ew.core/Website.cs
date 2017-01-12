using Couchbase.Linq.Filters;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core
{  

    [DocumentTypeFilter("Website")]
    public class Website : EwDocument
    {
        public Website() : base("Website")
        {
            Accounts = new List<AccountsAccessLevelOfWebsite>();
            Stagging = new List<DeploymentEnvironment>();
            Production = new List<DeploymentEnvironment>();
        }

        public string DisplayName { get; set; }
        public List<AccountsAccessLevelOfWebsite> Accounts { get; set; }// client push id
        public string Name { get; set; }//client
        public string Url { get; set; }
        public List<DeploymentEnvironment> Stagging { get; set; }
        public List<DeploymentEnvironment> Production { get; set; }
        public string WebTemplateId { get; set; }
        public string Source { get; set; }
        public string Git { get; set; }
        public string WebsiteType { get; set; }
    }

    public class WebsiteIdentity
    {
        public string WebsiteId { get; set; }
        public string DisplayName { get; set; }

        public WebsiteIdentity(Website website)
        {
            WebsiteId = website.Id;
            DisplayName = website.DisplayName;
        }
        public WebsiteIdentity() { }
    }

    public class AccountsAccessLevelOfWebsite
    {
        public string AccountId { get; set; }
        public List<string> AccessLevels { get; set; }
    }

    public class DeploymentEnvironment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HostingFee { get; set; }
        public string Url { get; set; }
        public string Git { get; set; }
        public bool IsDefault { get; set; }
    }
}
