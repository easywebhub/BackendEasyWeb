using ew.application;
using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.common.Entities;
using ew.core.Users;
using ew.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ew.webapi.Controllers
{
    /// <summary>
    /// Tài khoản
    /// </summary>
    [RoutePrefix("users")]
    public class AccountController : BaseApiController
    {
        private readonly IWebsiteManager _websiteManager;
        private readonly IAccountManager _accountManager;

        public AccountController(IWebsiteManager websiteManager, IAccountManager accountManager)
        {
            _websiteManager = websiteManager;
            _accountManager = accountManager;
        }

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Users(int limit = 20, int page = 1)
        {
            var data = _accountManager.GetListAccount(new core.Dtos.AccountQueryParams() { Limit = limit, Offset = (page - 1) * limit }).ToList();
            return Pagination(data.Select(x => new AccountInfoDto(x)).ToList(), _accountManager.EwhCount, limit, page);
        }

        /// <summary>
        /// Tạo mới tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(AddAccountDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_accountManager.CreateAccount(dto))
            {
                return Ok(_accountManager.EwhAccountAdded);
            }
            else
            {
                return ServerError(_accountManager as EwhEntityBase);
            }
        }


        /// <summary>
        /// Lấy thông tin chi tiết của 1 tài khoản
        /// </summary>
        /// <param name="userId">id của tài khoản</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult Users(string userId)
        {
            var data = _accountManager.GetEwhAccount(userId);
            if (data == null) return NotFound();
            return Ok(new AccountDetailDto(data));
        }
        

        /// <summary>
        /// Chỉnh sửa thông tin của 1 tài khoản
        /// </summary>
        /// <param name="userId">id tài khoản</param>
        /// <param name="dto">thông tin tài khoản</param>
        /// <returns></returns>
        [HttpPut, HttpPatch]
        [Route("{userId}")]
        public IHttpActionResult UpdateUserInfo(string userId, AccountInfo dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var ewhAccount = _accountManager.GetEwhAccount(userId);
            if (ewhAccount == null) return NotFound();
            if (ewhAccount.UpdateInfo(dto))
            {
                return Ok();
            }
            else
            {
                return ServerError(ewhAccount);
            }
        }

        /// <summary>
        /// Lấy danh sách website được quản trị bởi tài khoản
        /// </summary>
        /// <param name="userId">id của tài khoản</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}/websites")]
        public IHttpActionResult GetWebsitesOfUser(string userId)
        {
            var account = _accountManager.GetEwhAccount(userId);

            if (account == null) return NotFound();
            return Ok(account.GetListWebsite().Select(x => new NyWebsiteInfoDto(x, userId)).ToList());
        }


        /// <summary>
        /// Tạo mới website
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{userId}/websites")]
        public IHttpActionResult UserCreateWebsite(string userId, UserCreateWebsiteDto dto)
        {
            var websiteController = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(WebsiteController)) as WebsiteController;
            websiteController.ControllerContext = this.ControllerContext;
            return websiteController.CreateWebsite(new CreateWebsiteDto(userId, dto));
            
        }

        /// <summary>
        /// Thêm quyền quản trị 1 website cho 1 tài khoản
        /// </summary>
        /// <param name="userId">id tài khoản</param>
        /// <param name="websiteId">id website</param>
        /// <param name="dto">Thông tin phân quyền</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{userId}/websites/{websiteId}")]
        public IHttpActionResult AddWebsiteAccount(string userId, string websiteId, AddWebsitePermissionDto dto)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();

            //dto.AccountId = userId;
            //dto.WebsiteId = websiteId;
            if (dto.AccessLevels == null || !dto.AccessLevels.Any()) dto.AccessLevels = new List<string>() { "dev", "test" };
            if (ewhWebsite.AddAccount(new AddWebsiteAccountDto() { AccessLevels = dto.AccessLevels, AccountId = userId }))
            {
                return NoContent();
            }
            return ServerError(ewhWebsite);
        }

        /// <summary>
        /// Chỉnh sửa quyền quản trị 1 website của tài khoản
        /// </summary>
        /// <param name="userId">id của tài khoản</param>
        /// <param name="websiteId">id của website</param>
        /// <param name="dto">thông tin phần quyền</param>
        /// <returns></returns>
        [HttpPut, HttpPatch]
        [Route("{userId}/websites/{websiteId}")]
        public IHttpActionResult UpdateWebsiteAccessLevel(string userId, string websiteId, AddWebsitePermissionDto dto)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();

            //dto.AccountId = userId;
            //dto.WebsiteId = websiteId;
            if (dto.AccessLevels == null || !dto.AccessLevels.Any()) dto.AccessLevels = new List<string>() { "dev", "test" };
            if (ewhWebsite.UpdateAccessLevel(new UpdateAccountAccessLevelToWebsite() { AccessLevels = dto.AccessLevels, AccountId = userId }))
            {
                //var ewhAccount = _accountManager.GetEwhAccount(userId);
                //ewhAccount.UpdateWebsiteName();
                return NoContent();
            }
            return ServerError(ewhWebsite);
        }


        /// <summary>
        /// Xóa quyền quản trị website của tài khoản
        /// </summary>
        /// <param name="userId">id tài khoản</param>
        /// <param name="websiteId">id của website</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{userId}/websites/{websiteId}")]
        public IHttpActionResult RemoveWebsiteAccount(string userId, string websiteId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(websiteId);
            if (ewhWebsite == null) return NotFound();

            if (ewhWebsite.RemoveAccount(userId))
            {
                return NoContent();
            }
            return ServerError(ewhWebsite);
        }




    }
}
