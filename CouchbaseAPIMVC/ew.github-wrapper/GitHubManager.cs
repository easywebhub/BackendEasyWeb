using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.github_wrapper
{
    public class GitHubManager
    {
        public Repository RepositoryAdded { get; set; }

        private string owner = "thanhtdvn";
        private string password = "Admin@123";
        private GitHubClient InitClient()
        {
            var client = new GitHubClient(new ProductHeaderValue("easywebhub"));
            var basicAuth = new Credentials(owner, password); // NOTE: not real credentials
            client.Credentials = basicAuth;

            return client;
        }

        public async Task<bool> CreateRepository(string reponame, string description)
        {
            var client = InitClient();            
            var str = string.Empty;

            var createRepo = new NewRepository(reponame);
            createRepo.Description = description;
            createRepo.Private = false;
            RepositoryAdded = null;
            RepositoryAdded = client.Repository.Create(createRepo).Result;
            return RepositoryAdded != null;
        }

        public async Task<Repository> GetRepository(string repoName)
        {
            var client = InitClient();
            return client.Repository.Get(owner, repoName).Result;
        }

       

    }
}
