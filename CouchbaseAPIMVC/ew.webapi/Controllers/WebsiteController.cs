using ew.application;
using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.application.Services;
using ew.cloudflare_wrapper;
using ew.common;
using ew.common.Entities;
using ew.core.Enums;
using ew.git_hook_listener;
using ew.github_wrapper;
using ew.gogs_wrapper;
using ew.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ew.webapi.Controllers
{
    
    /// <summary>
    /// Website
    /// </summary>
    [RoutePrefix("websites")]
    public class WebsiteController : BaseApiController
    {
        private readonly IWebsiteManager _websiteManager;
        private readonly IAccountManager _accountManager;
        private readonly IEwhMapper _ewhMapper;

        //public WebsiteController(bool manualInit)
        //{
        //    _websiteManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IWebsiteManager)) as IWebsiteManager;
        //    _accountManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAccountManager)) as IAccountManager;
        //}

        public WebsiteController(IWebsiteManager websiteManager, IAccountManager accountManager, IEwhMapper ewhMapper)
        {
            _websiteManager = websiteManager;
            _accountManager = accountManager;
            _ewhMapper = ewhMapper;
        }

        public void SyncWebsiteRepositoryName()
        {
            var websites = _websiteManager.GetListEwhWebsite();
            foreach (var web in websites)
            {
                web.Save();
            }
        }

        /// <summary>
        /// Lấy danh sách websites
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Websites()
        {
            var data = _websiteManager.GetListEwhWebsite();

            return Ok(data.Select(x => new WebsiteInfoDto(x)).ToList());
        }

        /// <summary>
        /// Tạo mới website
        /// </summary>
        /// <param name="dto">AddNewWebsite model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateWebsite(CreateWebsiteDto dto)
        {
            if (ModelState.IsValid)
            {
                if (_websiteManager.CreateWebsite(dto))
                {
                    return Ok(new WebsiteInfoDto(_websiteManager.EwhWebsiteAdded));
                }
                return ServerError(_websiteManager as EwhEntityBase);
            }
            return BadRequest();
        }

        /// <summary>
        /// Full Tạo mới website
        /// </summary>
        /// <param name="dto">AddNewWebsite model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("fulladd")]
        public IHttpActionResult CreateWebsite(WebsiteDetailDto dto)
        {
            dto.WebsiteId = string.Empty;
            if (ModelState.IsValid)
            {
                if (_websiteManager.CreateWebsite(dto.ToEntity(_websiteManager.InitEwhWebsite())))
                {
                    return Ok(dto);
                }
                return ServerError(_websiteManager as EwhEntityBase);
            }
            return BadRequest();
        }

        /// <summary>
        /// Full update website
        /// </summary>
        /// <param name="dto">AddNewWebsite model</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{websiteId}/fullupdate")]
        public IHttpActionResult UpdateWebsite(string websiteId, WebsiteDetailDto dto)
        {
            dto.WebsiteId = websiteId;
            if (ModelState.IsValid)
            {
                var website = _websiteManager.GetEwhWebsite(dto.WebsiteId);
                if (website!=null && website.IsExits())
                {
                    if (_websiteManager.UpdateWebsite(dto.ToEntity(website)))
                    {
                        EwhLogger.Common.Info("FullUpdate End");
                        return Ok(dto);
                    }
                    return ServerError(_websiteManager as EwhEntityBase);
                }
                else
                {
                    return BadRequest();
                }
                return ServerError(_websiteManager as EwhEntityBase);
            }
            return BadRequest();
        }

        [Route("{websiteId}/sync")]
        public IHttpActionResult SyncData(string websiteId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if(ewhWebsite!=null && ewhWebsite.IsExits())
            {
                //ewhWebsite.SelfSync();
                MethodASync();
            }
            EwhLogger.Common.Info("Seft");
            return Ok();
        }

        public async Task<bool> MethodASync()
        {
            //await Task.Delay(2000);
            EwhLogger.Common.Info("SeftSync");
            for (int i = 1; i < 1000; i++)
            {
                EwhLogger.Common.Info(i);
            }
            return true;
        }

        /// <summary>
        /// Duyệt website -> init source git, demo, production repository
        /// </summary>
        /// <param name="websiteId">id of website</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{websiteId}/confirm")]
        public IHttpActionResult ConfirmWebsite(string websiteId)
        {
            if (ModelState.IsValid)
            {
                var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
                if (ewhWebsite == null) return NotFound();
                var githubManager = new GitHubManager();
                Octokit.Repository gitRepository = null;
                //create github repository
                if (string.IsNullOrEmpty(ewhWebsite.Git))
                {
                    if (githubManager.CreateRepository(ewhWebsite.RepositoryName, ewhWebsite.DisplayName).Result)
                    {
                        ewhWebsite.Git = githubManager.RepositoryAdded.CloneUrl;
                        ewhWebsite.Save();
                    }
                }else
                {
                    gitRepository = githubManager.GetRepository(repoName: ewhWebsite.RepositoryName).Result;
                }

                // add web-hook to demo & production server
                var ewhGogsSource = new EwhSource();
                var ewhAccountAsOwner = _accountManager.GetEwhAccount(ewhWebsite.GetOwnerId());
                if (ewhAccountAsOwner != null)
                {
                    ewhGogsSource.CreateWebHook(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName, ew.config.DemoServer.WebHookUrl);
                    ewhGogsSource.CreateWebHook(ewhAccountAsOwner.UserName, ewhWebsite.RepositoryName, ew.config.ProductionServer.WebHookUrl);
                }

                // add git-hook-listerner to demo + production servers
                if (string.IsNullOrEmpty(ewhWebsite.Source))
                {
                    ewhWebsite.InitGogSource();
                }
                if (string.IsNullOrEmpty(ewhWebsite.Source))
                {
                    return NoOK("Source_Empty");
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

                if (gitRepository != null)
                {
                    var sourceRepoUrl = ewhWebsite.Source;
                    var ewhGitHookListener = new EwhGitHookListener();
                    var demoGitHook = new git_hook_listener.Models.CreateGitHookListenerConfigDto()
                    {
                        GitHookListenerBaseUrl = ew.config.DemoServer.BaseUrl,
                        RepoUrl = sourceRepoUrl,
                        Branch = "master",
                        CloneBranch = "master",
                        Path = string.Format("repositories/{0}", gitRepository.Name)
                    };
                    if (ewhGitHookListener.CreateGitHookListernerConfig(demoGitHook))
                    {
                        ewhWebsite.AddStagging(new UpdateDeploymentEnvironmentToWebsite() { Url = websiteDomain, Git = sourceRepoUrl, HostingFee = HostingFees.Free.ToString(), Name = "EasyWeb Environment" });
                    }

                    var productionGitHook = new git_hook_listener.Models.CreateGitHookListenerConfigDto()
                    {
                        GitHookListenerBaseUrl = ew.config.ProductionServer.BaseUrl,
                        RepoUrl = sourceRepoUrl,
                        Branch = "master",
                        CloneBranch = "master",
                        Path = string.Format("repositories/{0}", gitRepository.Name)
                    };
                    if (ewhGitHookListener.CreateGitHookListernerConfig(productionGitHook))
                    {
                        ewhWebsite.AddProduction(new UpdateDeploymentEnvironmentToWebsite() { Git = sourceRepoUrl, HostingFee = HostingFees.Basic.ToString(), Name = "Production Enviroment" });
                    }
                }
                

                return Ok(new WebsiteDetailDto(ewhWebsite));
            }
            return BadRequest();
        }

        /// <summary>
        /// Lấy thông tin chi tiết 1 website
        /// </summary>
        /// <param name="websiteId">Id của website</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{websiteId}")]
        public IHttpActionResult Websites(string websiteId)
        {
            var data = _websiteManager.GetEwhWebsite(websiteId);
            if (data == null) return NotFound();
            return Ok(new WebsiteDetailDto(data));
        }

        /// <summary>
        /// Lấy danh sách user được quản trị website
        /// </summary>
        /// <param name="websiteId">id của website</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{websiteId}/users")]
        public IHttpActionResult Users(string websiteId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            return Ok(ewhWebsite.GetListAccount().Select(x => new AccountInfoCanAccessWebsiteDto(x, websiteId)).ToList());
        }

        /// <summary>
        /// Thêm tài khoản được phép quản trị website
        /// </summary>
        /// <param name="websiteId">mã website</param>
        /// <param name="userId">mã tài khoản</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{websiteId}/users/{userId}")]
        public IHttpActionResult AddUser(string websiteId, string userId, AddWebsitePermissionDto dto)
        {
            var accountController = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(AccountController)) as AccountController;
            accountController.ControllerContext = this.ControllerContext;
            return accountController.AddWebsiteAccount(userId, websiteId, dto);
        }

        /// <summary>
        /// Chỉnh sửa quyền quản trị website của 1 tài khoản
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="userId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut, HttpPatch]
        [Route("{websiteId}/users/{userId}")]
        public IHttpActionResult UpdateUserAccessLevel(string websiteId, string userId, AddWebsitePermissionDto dto)
        {
            var accountController = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(AccountController)) as AccountController;
            accountController.ControllerContext = this.ControllerContext;
            return accountController.UpdateWebsiteAccessLevel(userId, websiteId, dto);
        }


        /// <summary>
        /// Remove tài khoản ra khỏi danh sách được phép quản trị website
        /// </summary>
        /// <param name="websiteId">mã website</param>
        /// <param name="userId">mã tài khoản</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{websiteId}/users/{userId}")]
        public IHttpActionResult RemoveUser(string websiteId, string userId)
        {
            var accountController = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(AccountController)) as AccountController;
            accountController.ControllerContext = this.ControllerContext;
            return accountController.RemoveWebsiteAccount(userId, websiteId);
        }

        /// <summary>
        /// Danh sách môi trường stagging của website
        /// </summary>
        /// <param name="websiteId">id của website</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{websiteId}/staggings")]
        public IHttpActionResult Staggings(string websiteId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            return Ok(ewhWebsite.Stagging);
        }

        /// <summary>
        /// Thêm mới 1 môi trường stagging cho website
        /// </summary>
        /// <param name="websiteId">id của website</param>
        /// <param name="dto">thông tin môi trường</param>
        /// <returns></returns>
        [HttpPut, HttpPatch]
        [Route("{websiteId}/staggings")]
        public IHttpActionResult AddStagging(string websiteId, UpdateDeploymentEnvironmentToWebsite dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            if (ewhWebsite.AddStagging(dto))
            {
                return Ok();
            }
            else
            {
                return ServerError(ewhWebsite);
            }
        }


        /// <summary>
        /// Xóa 1 môi trường stagging khỏi website
        /// </summary>
        /// <param name="websiteId">id website</param>
        /// <param name="staggingId">id môi trường stagging</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{websiteId}/staggings/{staggingId}")]
        public IHttpActionResult RemoveStagging(string websiteId, string staggingId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            if (ewhWebsite.RemoveStaging(staggingId))
            {
                return Ok();
            }
            else
            {
                return ServerError(ewhWebsite);
            }
        }


        /// <summary>
        /// Danh sách môi trường production của website
        /// </summary>
        /// <param name="websiteId">id của website</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{websiteId}/productions")]
        public IHttpActionResult Productions(string websiteId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            return Ok(ewhWebsite.Production);
        }

        /// <summary>
        /// Thêm mới 1 môi trường production cho website
        /// </summary>
        /// <param name="websiteId">id của website</param>
        /// <param name="dto">thông tin môi trường</param>
        /// <returns></returns>
        [HttpPut, HttpPatch]
        [Route("{websiteId}/productions")]
        public IHttpActionResult AddProduction(string websiteId, UpdateDeploymentEnvironmentToWebsite dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            if (ewhWebsite.AddProduction(dto))
            {
                return Ok();
            }
            else
            {
                return ServerError(ewhWebsite);
            }
        }


        /// <summary>
        /// Xóa 1 môi trường production khỏi website
        /// </summary>
        /// <param name="websiteId">id website</param>
        /// <param name="productionId">id môi trường production</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{websiteId}/productions/{productionId}")]
        public IHttpActionResult RemoveProduction(string websiteId, string productionId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();
            if (ewhWebsite.RemoveProduction(productionId))
            {
                return Ok();
            }
            else
            {
                return ServerError(ewhWebsite);
            }
        }


    }
}
