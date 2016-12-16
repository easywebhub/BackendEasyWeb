using ew.application.Entities;
using ew.application.Services;
using ew.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ew.webapi.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Route("signin")]
        public IHttpActionResult SignIn(SignInDto dto)
        {
            if (!ModelState.IsValid) return InvalidRequest();
            if(_authService.CheckUserAuth(dto.Username, dto.Password))
            {
                return Ok(new AccountInfoDto(_authService.AuthorizedAccount()));
            }
            return NoOK(_authService as EwhEntityBase);
        }


    }
}
