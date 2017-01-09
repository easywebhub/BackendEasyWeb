using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.git_hook_listener.Models
{
    public class Repository
    {
        public string RepoUrl { get; set; }
        public string Branch { get; set; }
        public string CloneBranch { get; set; }
        public string Path { get; set; }
        public List<string> Args { get; set; }

        public Repository()
        {
            this.Args = new List<string>();
        }
    }

    public class CreateGitHookListenerConfigDto: Repository
    {
        public string GitHookListenerBaseUrl { get; set; }
        public string BasicAuthUsername { get; set; }
        public string BasicAuthPassword { get; set; }

        public CreateGitHookListenerConfigDto(): base()
        {

        }
    }
}
