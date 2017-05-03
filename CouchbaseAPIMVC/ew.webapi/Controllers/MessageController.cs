using ew.application.Services;
using ew.common.Entities;
using ew.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ew.webapi.Controllers
{
    public class MessageController : BaseApiController
    {
        #region mail
        /// <summary>
        /// Gửi mail
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mail/compose")]
        public IHttpActionResult SendMail(Request_SendMailDto dto)
        {
            if (ModelState.IsValid)
            {
                var mailService = new MailService("smtp.yandex.ru", 587, true, "reply@easyadmincp.com", "ew!@#456");
                if (mailService.Send("reply@easyadmincp.com", dto.MailTo, dto.MailBccs, dto.Subject, dto.Body))
                {
                    return Ok();
                }
                return NoOK(core.Enums.GlobalStatus.UnSuccess);
            }
            return BadRequest();
        }

        /// <summary>
        /// Gửi mail đăng ký thành công
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mail/registersuccess")]
        public IHttpActionResult SendMailRegisterSuccess(Request_SendMailRegisterSuccessDto dto)
        {
            var sendmailDto = new Request_SendMailDto() { Subject = "Đăng ký tài khoản thành công", Body = "Chúc mừng bạn đã đăng ký tài khoản easyweb thành công.", MailTo = dto.MailTo, MailBccs = dto.MailBccs };
            return SendMail(sendmailDto);
        }
                
        #endregion
    }
}
