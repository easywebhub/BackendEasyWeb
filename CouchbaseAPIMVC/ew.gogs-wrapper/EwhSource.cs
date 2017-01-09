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
            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest("repos", Method.POST) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            request.AddBody(new { username = gogsUsername, repositoryName = repositoryName });
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                RepositoryAdded = JsonHelper.DeserializeObject<Repository>(response.Content);
                return true;
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
            }else
            {
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return new List<Repository>();
        }


        public bool CreateWebHook(string gogsUsername, string repositoryName, string deployServerUrl)
        {
            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest(string.Format("repos/{0}/{1}/hooks", gogsUsername, repositoryName), Method.POST) { RequestFormat = DataFormat.Json };
            var data = new { url = deployServerUrl, secret = "Web!@#456Hook", active = false };
            //"url": "http://deploy.server/project/hook",
            //"secret": "bat-mi",
            //"active": false
            request.AddBody(data);
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");

            this.WebHookAdded = null;
            var response = _client.Execute(request);
            if (response != null && response.ResponseStatus == ResponseStatus.Completed)
            {
                WebHookAdded = JsonHelper.DeserializeObject<WebHook>(response.Content);
                return true;
            }else
            {
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return false;
        }
    }
}
