using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities.Dto
{
    public class CreateWebsiteDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public List<AddWebsiteAccountDto> Accounts { get; set; }
        public string WebTemplateId { get; set; }
    }

    public class UpdateDeploymentEnvironmentToWebsite
    {
        //public string WebsiteId { get; set; } // Add/Update/Remove
        public string EnviromentId { get; set; }
        public string Name { get; set; }
        public string HostingFee { get; set; }
        public string Url { get; set; }
        public string Git { get; set; }
        public bool IsDefault { get; set; }
    }

    public class UpdateAccountAccessLevelToWebsite
    {
        //public string WebsiteId { get; set; }
        public string AccountId { get; set; }
        public List<string> AccessLevels { get; set; }

        public UpdateAccountAccessLevelToWebsite()
        {
            AccessLevels = new List<string>();
        }
    }


}
