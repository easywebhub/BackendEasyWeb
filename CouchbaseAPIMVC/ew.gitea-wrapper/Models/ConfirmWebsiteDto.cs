using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.gitea_wrapper.Models
{
    public class ConfirmWebsiteDto
    {
        public string username { get; set; }
        public string repositoryName { get; set; }
        public string templateName { get; set; } // template name to migration
        public string githubUsername { get; set; } // need for create github project
        public string githubPassword { get; set; } // need for create github project
        public string cloudflareEmail { get; set; }
        public string cloudflareKey { get; set; }
        public string baseDomain { get; set; } // base domain of cloudflare account eg. easywebhub.me
        public string sourceServerUrl { get; set; } // gitea server url eg. https://sourcecode.easywebhub.com
        public string gitHookUrl { get; set; } // url gitea will call when there is push event eg. "https://demo.easywebhub.com/web-hook"
        public string gitHookSecret { get; set; } // must match with gitHookListener
        public string gitHookListenerUrl { get; set; } // eg. https://demo.easywebhub.com/repositories

        public ConfirmWebsiteDto()
        {
            cloudflareEmail = "contact@vinaas.com";
            cloudflareKey = "79e7ac8b61f3c481c6182a523fbf320b74b07";
            githubUsername = "ewh-support";
            githubPassword = "78cda58cd8753fc091d0f15727788718ebd40656";
            baseDomain = "easywebhub.me";
            sourceServerUrl = "https://sourcecode.easywebhub.com";
            gitHookUrl = "https://demo.easywebhub.com/web-hook";
            gitHookSecret = "bay gio da biet";
            gitHookListenerUrl = "https://demo.easywebhub.com/repositories";
        }
        public ConfirmWebsiteDto(string username, string repositoryName, string templateName):this()
        {
            this.username = username;
            this.repositoryName = repositoryName;
            this.templateName = templateName;
        }
    }

    public class Res_ConfirmWebsiteDto
    {
        public string Source { get; set; }
        public string Git { get; set; }
        public string Url { get; set; }
    }
}
