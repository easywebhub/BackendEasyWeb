using ew.common;
using ew.common.Helper;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ew.github_wrapper
{
    public class GitHubManager
    {
        public Repository RepositoryAdded { get; set; }

        public string owner = "thanhtdvn";
        public string password = "Admin@123";
        private GitHubClient InitClient()
        {
            var client = new GitHubClient(new ProductHeaderValue("easywebhub"));
            var basicAuth = new Credentials(owner, password); // NOTE: not real credentials
            client.Credentials = basicAuth;

            return client;
        }

        public async Task<bool> CreateRepository(string reponame, string description)
        {
            EwhLogger.Common.Debug("Create github repo : "+ JsonHelper.SerializeObject(new { RepoName = reponame, Desc = description }));
            var client = InitClient();            
            var str = string.Empty;

            var createRepo = new NewRepository(reponame);
            createRepo.Description = description;
            createRepo.Private = false;
            RepositoryAdded = null;
            try
            {
                RepositoryAdded = client.Repository.Create(createRepo).Result;
            }catch(Exception ex)
            {
                EwhLogger.Common.Debug("Create github repo Failed: " + JsonHelper.SerializeObject(ex));
                return false;
            }
            
            if (RepositoryAdded != null)
            {
                EwhLogger.Common.Debug("Create github repo Success: "+ JsonHelper.SerializeObject(RepositoryAdded));
                return true;
            }
            EwhLogger.Common.Debug("Create github repo Falied ");
            return false;
        }

        public async Task<Repository> GetRepository(string repoName)
        {
            var client = InitClient();
            return client.Repository.Get(owner, repoName).Result;
        }

        public string GetGitUrlIncludePassword(string git)
        {
            git = git.Replace("//github.com/", string.Format("//{0}:{1}@github.com/", this.owner, HttpUtility.UrlEncode(this.password)));
            return git;
        }

    }
}
