using ew.common.Entities;
using ew.common.Helper;
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
    public class EwhSource: EwhEntityBase
    {
        public Repository RepositoryAdded { get; private set; }

        private string GogsBaseUrl = "http://212.47.253.180:7000/";

        public bool CreateRepository(string username, string repositoryName)
        {
            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest("repos", Method.POST) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            request.AddBody(new { username = username, repositoryName = repositoryName });
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
            }
            return new List<Repository>();
        }

    }
}
