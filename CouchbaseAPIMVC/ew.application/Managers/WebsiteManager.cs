using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.application.Services;
using ew.common.Entities;
using ew.core.Enums;
using ew.core.Repositories;
using ew.core.Users;
using ew.gogs_wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application
{
    public class WebsiteManager : EwhEntityBase, IWebsiteManager
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly Lazy<IEwhMapper> _ewhMapper;
        private IEwhMapper ewhMapper { get { return _ewhMapper.Value; } }

        public WebsiteManager(IWebsiteRepository websiteRepository, IAccountRepository accountRepository, Lazy<IEwhMapper> ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        public EwhWebsite EwhWebsiteAdded { get; private set; }

        public EwhWebsite ewhWebsite {get;} 
        public bool ConfirmWebsite(string websiteId)
        {
            ewhWebsite = GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return false; // NotFound();
            
            
            //kiểm tra source gogs repo đã tạo chưa, chưa thì tạo mới và kiểm tra lại
            if (string.IsNullOrEmpty(ewhWebsite.Source))
            {
                ewhWebsite.InitGogSource();
            }
            if (string.IsNullOrEmpty(ewhWebsite.Source))
            {
                return false; // NoOK("Source_Empty");
            }

            // add web-hook to demo & production server
            //var ewhGogsSource = new EwhSource();
            var ewhAccountAsOwner = _accountManager.GetEwhAccount(ewhWebsite.GetOwnerId());
            if (ewhAccountAsOwner != null)
            {
                //Bao: nhiều new class như vậy: ewhGogsSource = new EwhSource và new EwhSource.CreateWebHookDto
                // ewhGogsSource.CreateWebHook(new EwhSource.CreateWebHookDto(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName));

                // ewhGogsSource.CreateWebHook(new EwhSource.CreateWebHookDto(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName, ew.config.ProductionServer.WebHookUrl, ew.config.ProductionServer.SecretKey));
          
                //ewhGogsSource.CreateWebHook_v2(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName);
                //ewhGogsSource.CreateWebHook_v2(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName, ew.config.ProductionServer.WebHookUrl, ew.config.ProductionServer.SecretKey);
                
                var ewhGogsSource = new EwhSource(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName)
                if (!ewhGogsSource.CreateWebHook_v2()) return false;

                ewhGogsSource = new EwhSource(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName,  ew.config.ProductionServer.WebHookUrl, ew.config.ProductionServer.SecretKey);
                if (!ewhGogsSource.CreateWebHook_v2()) return false;
            }
            
            // create sub domain
            var websiteDomain = string.Empty;
            var subDomainName = string.Format("{0}-{1}.{2}", ewhAccountAsOwner.UserName, ewhWebsite.Name, ew.config.CloudflareInfo.EwhDomain).ToLower();
            var cloudflareManager = new CloudflareManager();
            if (cloudflareManager.CreateDNSRecord(ew.config.CloudflareInfo.EwhCloudflareZoneId, new cloudflare_wrapper.Models.UpdateDNSRecordDto() { Type = "CNAME", Name = subDomainName, Content = "easywebhub.github.io" }))
            {
                websiteDomain = cloudflareManager.DNSRecordAdded.name;
            }
            else
            {

            }

            if (CreateGithubRepo() == false)
            {
                return false; 
                //return NoOK("Can not create github repository");
            }
            
            return true;
        } 

        private bool CreateGithubRepo()
        {
            var githubManager = new GitHubManager();
            Octokit.Repository gitRepository = null;
            //create github repository
            if (string.IsNullOrEmpty(ewhWebsite.Git))
            {
                if (githubManager.CreateRepository(ewhWebsite.RepositoryName, ewhWebsite.DisplayName).Result)
                {
                    gitRepository = githubManager.RepositoryAdded;
                    ewhWebsite.Git = githubManager.RepositoryAdded.CloneUrl;
                    ewhWebsite.Save();
                }else
                {
                    EwhLogger.Common.Debug(string.Format("Create Repository Failed: {0} - {1}", ewhWebsite.RepositoryName, ewhWebsite.DisplayName));
                    return false; //return NoOK("Can not create github repository");
                }
            }else
            {
                gitRepository = githubManager.GetRepository(repoName: ewhWebsite.RepositoryName).Result;
            }

            if (gitRepository != null)
            {
                var gitUrlIncludePass = githubManager.GetGitUrlIncludePassword(ewhWebsite.Git);
                var sourceRepoUrl = ewhWebsite.Source;
                var ewhGitHookListener = new EwhGitHookListener();

                //bao: cần refactor theo từng function riêng dành cho demoGithook và productionGithook 
                var demoGitHook = new git_hook_listener.Models.CreateGitHookListenerConfigDto()
                {
                    GitHookListenerBaseUrl = ew.config.DemoServer.BaseUrl,
                    repoUrl = sourceRepoUrl,
                    branch = "gh-pages",
                    cloneBranch = "gh-pages",
                    path = string.Format("repositories/{0}", gitRepository.Name),
                    args = new List<string>(),
                    then = new List<git_hook_listener.Models.RepoCommand>()
                };
                demoGitHook.then.Add(new git_hook_listener.Models.RepoCommand() { command = "git", args = new List<string>() { "remote", "add", "github", gitUrlIncludePass }, options = new git_hook_listener.Models.RepoCommandOption() { cwd= demoGitHook.path} });
                demoGitHook.then.Add(new git_hook_listener.Models.RepoCommand() { command = "git", args = new List<string>() { "push", "--force", "github", "HEAD:gh-pages" }, options = new git_hook_listener.Models.RepoCommandOption() { cwd = demoGitHook.path } });

                if (ewhGitHookListener.CreateGitHookListernerConfig(demoGitHook))
                {
                    ewhWebsite.AddStagging(new UpdateDeploymentEnvironmentToWebsite() { Url = websiteDomain, Git = sourceRepoUrl, HostingFee = HostingFees.Free.ToString(), Name = "EasyWeb Environment" });
                }

                var productionGitHook = new git_hook_listener.Models.CreateGitHookListenerConfigDto()
                {
                    GitHookListenerBaseUrl = ew.config.ProductionServer.BaseUrl,
                    repoUrl = sourceRepoUrl,
                    branch = "master",
                    cloneBranch = "master",
                    path = string.Format("repositories/{0}", gitRepository.Name)
                };
                productionGitHook.then.Add(new git_hook_listener.Models.RepoCommand() { command = "git", args = new List<string>() { "remote", "add", "github", gitUrlIncludePass }, options = new git_hook_listener.Models.RepoCommandOption() { cwd = productionGitHook.path } });
                productionGitHook.then.Add(new git_hook_listener.Models.RepoCommand() { command = "git", args = new List<string>() { "push", "--force", "github", "gh-pages" }, options = new git_hook_listener.Models.RepoCommandOption() { cwd = productionGitHook.path } });

                if (ewhGitHookListener.CreateGitHookListernerConfig(productionGitHook))
                {
                    ewhWebsite.AddProduction(new UpdateDeploymentEnvironmentToWebsite() { Git = sourceRepoUrl, HostingFee = HostingFees.Basic.ToString(), Name = "Production Enviroment" });
                }
            }else
            {
               return false;   
            }
            
            return true; 
        }

        public bool CreateWebsite(CreateWebsiteDto dto)
        {
            var ewhWebsite = new EwhWebsite(_websiteRepository, _accountRepository, _ewhMapper);
            ewhMapper.ToEntity(ewhWebsite, dto);
            ewhWebsite.WebsiteType = WebsiteTypes.Free.ToString();
            var check = false;
            // create website
            if (ewhWebsite.Create())
            {
                check = true;
                ewhWebsite.InitGogSource();
                EwhWebsiteAdded = ewhWebsite;
            }
            SyncStatus(this, ewhWebsite);
            return check;
        }

        private bool CheckValidWebsite(EwhWebsite website)
        {
            var owner = website.Accounts.FirstOrDefault(x => x.AccessLevels.Contains(AccessLevels.Owner.ToString()));
            Account accountAsOwner;
            if (owner == null)
            {
                this.EwhStatus = GlobalStatus.HaveNoAnOwner;
                return false;
            }
            return true;
        }

        public bool CreateWebsite(EwhWebsite ewhWebsite)
        {
            if (!CheckValidWebsite(ewhWebsite)) return false;
            ewhWebsite.Create();
            return true;
        }

        public bool UpdateWebsite(EwhWebsite website)
        {
            if (!CheckValidWebsite(website)) return false;
            website.Save();
            website.SelfSync();
            return true;
        }

        public EwhWebsite GetEwhWebsite(string id)
        {
            var website = _websiteRepository.Get(id);
            if (website == null)
            {
                EwhStatus = core.Enums.GlobalStatus.NotFound;
                return null;
            }
            return new EwhWebsite(website, _websiteRepository, _accountRepository, _ewhMapper);
        }

        public List<EwhWebsite> GetListEwhWebsite()
        {
            return ewhMapper.ToEwhWebsites(_websiteRepository.FindAll().OrderByDescending(x=>x.CreatedDate).ToList());
        }

        public List<EwhWebsite> GetListEwhWebsite(List<string> WebsiteIds)
        {
            return ewhMapper.ToEwhWebsites(_websiteRepository.FindAll().Where(x=>WebsiteIds.Contains(x.Id)).OrderByDescending(x => x.CreatedDate).ToList());
        }

        public void SyncWebsite(string id)
        {
            var website = GetEwhWebsite(id);
            if (website.IsExits())
            {
                website.SelfSync();
            }
        }

        public EwhWebsite InitEwhWebsite()
        {
            return new EwhWebsite(_websiteRepository, _accountRepository, _ewhMapper);
        }

        
    }
}
