using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.git_hook_listener.Models
{
    public class Repository
    {
        public string repoUrl { get; set; }
        public string branch { get; set; }
        public string cloneBranch { get; set; }
        public string path { get; set; }
        public List<string> args { get; set; }
        public List<RepoCommand> then { get; set; }
        public Repository()
        {
            this.args = new List<string>();
            this.then = new List<RepoCommand>();
        }
    }
    public class RepoCommand
    {
        public string command { get; set; }
        public List<string> args { get; set; }
        public RepoCommandOption options { get; set; }

        public RepoCommand()
        {
            this.args = new List<string>();
        }
    }

    public class RepoCommandOption
    {
        public string cwd { get; set; }
    }

    public class CreateGitHookListenerConfigDto: Repository
    {
        public string GitHookListenerBaseUrl { get; set; }
        //public string BasicAuthUsername { get; set; }
        //public string BasicAuthPassword { get; set; }

        public CreateGitHookListenerConfigDto(): base()
        {

        }
    }
}
