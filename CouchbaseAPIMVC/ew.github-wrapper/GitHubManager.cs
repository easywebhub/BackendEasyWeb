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

        public async Task<bool> CreateRepository(string reponame, string description)
        {
            var client = new GitHubClient(new ProductHeaderValue("easywebhub"));
            var basicAuth = new Credentials("ewh-support", "!@#456"); // NOTE: not real credentials
            client.Credentials = basicAuth;
            
            var str = string.Empty;

            var createRepo = new NewRepository(reponame);
            createRepo.Description = description;
            createRepo.Private = false;
            RepositoryAdded = null;
            RepositoryAdded = client.Repository.Create(createRepo).Result;
            return RepositoryAdded != null;
        }

       

    }
}
