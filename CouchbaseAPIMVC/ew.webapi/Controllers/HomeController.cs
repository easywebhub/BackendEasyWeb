using ew.application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ew.webapi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var mailService = new MailService("smtp.yandex.ru", 587, true, "reply@easyadmincp.com", "ew!@#456");
            //ViewBag.SentMail = mailService.Send("reply@easyadmincp.com", "reply@easyadmincp.com", "truongducthanh88@gmail.com", "Test send mail", "HELLO THE WORLD!");
            //mailService.Send("reply@easyadmincp.com", "reply@easyadmincp.com", "truongducthanh88@gmail.com", "Test send mail", "<html><h1 style=\"color: red;\">HELLO</h1><a href=\"google.com\">LAN</a><html>");
            mailService.Send("reply@easyadmincp.com", "reply@easyadmincp.com", "truongducthanh88@gmail.com,truongducthanh@vienthonga.vn", "Test send mail1", "BCC TEST");
            mailService.Send("reply@easyadmincp.com", "truongducthanh88@gmail.com", "", "Test send mail2", "BCC TEST");
            mailService.Send("reply@easyadmincp.com", "truongducthanh88@gmail.com", "truongducthanh@vienthonga.vn", "Test send mail3", "BCC TEST");
            return View();
        }
    }
}
