using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Dto
{
    public class DeploymentEnviromentModel
    {
        public Website Website { get; set; }
        public string Type { get; set; }
        public string EnviromentId { get; set; }
        public string Name { get; set; }
        public string HostingFee { get; set; }
        public string Url { get; set; }
        public string Git { get; set; }
        public bool IsDefault { get; set; }
    }
}
