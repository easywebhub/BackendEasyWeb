using ew.application;
using ew.common.Helper;
using ew.webapi.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Octokit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ew.webapi.Controllers
{
    [RoutePrefix("sources")]
    public class GitHubController : BaseApiController
    {
        private readonly IWebsiteManager _websiteManager;
        private readonly IAccountManager _accountManager;

        public GitHubController(IWebsiteManager websiteManager, IAccountManager accountManager)
        {
            _websiteManager = websiteManager;
            _accountManager = accountManager;
        }


        [HttpGet]
        public async Task<string> Test()
        {
            var owner = string.Empty;
            var reponame = string.Empty;

            owner = "baotnq";
            reponame = "deployments";

            var client = new GitHubClient(new ProductHeaderValue("easywebhub"));
            var basicAuth = new Credentials("thanhtdvn", "******"); // NOTE: not real credentials
            client.Credentials = basicAuth;

            var str = string.Empty;

            //var user = await client.User.Get("shiftkey");
            //str += string.Format("{0} has {1} public repositories - go check out their profile at {2}",
            //    user.Name,
            //    user.PublicRepos,
            //    user.Url);

            // you can also specify a search term here
            var request = new SearchRepositoriesRequest("bootstrap");

            var result = await client.Search.SearchRepo(request);
            var createRepo = new NewRepository("repo_was_created_by_api");
            createRepo.Description = "repository was create by Thanh by call api";
            var res = await client.Repository.Create(createRepo);
            str += res.CloneUrl;

            //var repository = await client.Repository.Get(owner, reponame);

            //str += String.Format("Octokit.net can be found at {0}\n", repository.HtmlUrl);

            //str+=string.Format("It currently has {0} watchers and {1} forks\n",
            //    repository.StargazersCount,
            //    repository.ForksCount);

            //str+=string.Format("It has {0} open issues\n", repository.OpenIssuesCount);

            //str+=string.Format("And GitHub thinks it is a {0} project", repository.Language);

            return str;

        }

        //[HttpGet]
        //public string GetCallDirectGithub()
        //{
        //    var _client = new RestClient("https://api.github.com/");
        //    var request = new RestRequest("/user/repos", Method.GET) { RequestFormat = DataFormat.Json };
        //    request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
        //    var response = _client.Execute(request);
        //    if (response != null)
        //    {
        //        return response.Content;
        //    }
        //    return "False";
        //}

        private string GogsBaseUrl = "http://212.47.253.180:7000/";

        [Route("repositories")]
        [HttpPost]
        public IHttpActionResult CreateRepository(CreateRepositoryDto dto)
        {
            if (!ModelState.IsValid) return InvalidRequest();
            var ewhAccount = _accountManager.GetEwhAccount(dto.AccountId);
            if (ewhAccount == null) return NotFound();

            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest("repos", Method.POST) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            request.AddBody(new { username = ewhAccount.UserName, repositoryName = dto.RepositoryName });
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(JsonHelper.DeserializeObject(response.Content));
            }
            return NoOK();
        }

        //[Route("repositories")]
        //[HttpGet]
        //public IHttpActionResult GetRepositories(int limit = 20, int page = 1)
        //{
        //    var data = _accountManager.GetListAccount(new core.Dtos.AccountQueryParams() { Limit = limit, Offset = (page - 1) * limit }).ToList();
        //    return Pagination(data.Select(x => new AccountInfoDto(x)).ToList(), _accountManager.EwhCount, limit, page);
        //}

        [Route("repositories/users/{userId}")]
        [HttpGet]
        public IHttpActionResult GetUserRepositories(string userId, int limit = 20, int page = 1)
        {
            if (!ModelState.IsValid) return InvalidRequest();
            var ewhAccount = _accountManager.GetEwhAccount(userId);
            if (ewhAccount == null) return NotFound();

            var _client = new RestClient(GogsBaseUrl);
            var request = new RestRequest("repos/"+ewhAccount.UserName, Method.GET) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                return Pagination(JsonHelper.DeserializeObject(response.Content), 1, limit, page);
            }
            return NoOK();
        }

        
    }
}
