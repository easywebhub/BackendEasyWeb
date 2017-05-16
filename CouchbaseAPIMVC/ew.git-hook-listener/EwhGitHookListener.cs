using ew.common;
using ew.common.Entities;
using ew.common.Helper;
using ew.git_hook_listener.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.git_hook_listener
{
    public class EwhGitHookListener: EwhEntityBase
    {
        public Repository GitHookListenerAdded { get; set; }
        //public string GitHookListenerServerBaseUrl  = "https://demo.easywebhub.com/";

        public bool CreateGitHookListernerConfig(CreateGitHookListenerConfigDto dto)
        {
            EwhLogger.Common.Debug("Create git-hook-listener : "+ JsonHelper.SerializeObject(dto));
            var _client = new RestClient(dto.GitHookListenerBaseUrl);
            //_client.Authenticator = new SimpleAuthenticator("username", dto.BasicAuthUsername, "password", dto.BasicAuthPassword);
            var request = new RestRequest(string.Format("repositories"), Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(dto);
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            
            this.GitHookListenerAdded = null;
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                EwhLogger.Common.Debug("Create git-hook-listener success: "+ response.Content);
                this.GitHookListenerAdded = JsonHelper.DeserializeObject<Repository>(response.Content);
                return true;
            }
            else
            {
                EwhLogger.Common.Debug("Create git-hook-listener failed: "+ JsonHelper.SerializeObject(response.ErrorException));
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return false;
        }
    }
}
