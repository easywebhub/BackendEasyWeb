using ew.common;
using ew.common.Entities;
using ew.common.Helper;
using ew.config;
using ew.gogs_wrapper.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ew.gogs_wrapper
{
    public class EwhSource : EwhEntityBase
    {
        public Repository RepositoryAdded { get; private set; }
        public WebHook WebHookAdded { get; set; }

        private string GogsBaseUrl = ew.config.SourceServer.BaseUrl;

        public bool CreateRepository(string gogsUsername, string repositoryName)
        {
            EwhLogger.Common.Debug("Create source repo : "+ JsonHelper.SerializeObject(new { GogsUserName = gogsUsername, RepoName = repositoryName }));
            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest("repos", Method.POST) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            request.AddBody(new { username = gogsUsername, repositoryName = repositoryName });
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                EwhLogger.Common.Error("Create source repo Success: ", JsonHelper.SerializeObject(response.Content));
                RepositoryAdded = JsonHelper.DeserializeObject<Repository>(response.Content);
                return true;
            }
            else
            {
                EwhLogger.Common.Error("Create source repo Falied: ",JsonHelper.SerializeObject(response.ErrorException));
            }
            return false;
        }

        //[Route("repositories")]
        //[HttpGet]
        //public IHttpActionResult GetRepositories(int limit = 20, int page = 1)
        //{
        //    var data = _accountManager.GetListAccount(new core.Dtos.AccountQueryParams() { Limit = limit, Offset = (page - 1) * limit }).ToList();
        //    return Pagination(data.Select(x => new AccountInfoDto(x)).ToList(), _accountManager.EwhCount, limit, page);
        //}

        public List<Repository> GetUserRepositories(string username, int limit = 20, int page = 1)
        {
            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest("repos/" + username, Method.GET) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");

            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                return JsonHelper.DeserializeObject<List<Repository>>(response.Content);
            }
            else
            {
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return new List<Repository>();
        }

        //bao: add them 2 function mới 
        public bool CreateWebhook_v2(string gogsUsername, string repoName)
        {
            return new CreateWebHookDto(gogsUsername,repoName);
          
        }
        
        public bool CreateWebhook_v2(string gogsUsername, string repoName, string deployUrl, string secret)
        {
            return new CreateWebHookDto(gogsUsername,repoName,deployUrl,secret);
          
        }

        public bool CreateWebHook(CreateWebHookDto dto)
        {
            EwhLogger.Common.Debug("=Create web-hook : "+ JsonHelper.SerializeObject(dto));
            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest(string.Format("repos/{0}/{1}/hooks", dto.GogsUsername, dto.RepositoryName), Method.POST) { RequestFormat = DataFormat.Json };
            var data = new { url = dto.ReployServerUrl, secret = dto.SecretKey, active = false };
            //"url": "http://deploy.server/project/hook",
            //"secret": "bat-mi",
            //"active": false
            request.AddBody(data);
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");

            this.WebHookAdded = null;
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                EwhLogger.Common.Debug("  ++ Success: "+ response.Content);
                WebHookAdded = JsonHelper.DeserializeObject<WebHook>(response.Content);
                return true;
            }
            else
            {
                EwhLogger.Common.Debug(" ++ Failed: "+ JsonHelper.SerializeObject(response.ErrorException));
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return false;
        }

        public class CreateWebHookDto
        {
            public string GogsUsername { get; }
            public string RepositoryName { get; }
            public string ReployServerUrl { get; }
            public string SecretKey { get; }

            public CreateWebHookDto(string gogsUsername, string repoName)
            {
                this.GogsUsername = gogsUsername;
                this.RepositoryName = repoName;
                ReployServerUrl = ew.config.DemoServer.WebHookUrl;
                SecretKey = ew.config.DemoServer.SecretKey;
            }
            public CreateWebHookDto(string gogsUsername, string repoName, string deployUrl, string secret)
            {
                this.GogsUsername = gogsUsername;
                this.RepositoryName = repoName;
                ReployServerUrl = deployUrl;
                SecretKey = secret;
            }
        }
    }
}
