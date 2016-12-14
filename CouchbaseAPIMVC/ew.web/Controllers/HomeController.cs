using ew.application;
using ew.application.Entities.Dto;
using ew.application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ew.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebsiteService _websiteService;
        private readonly IWebsiteManager _websiteManager;
        private readonly IAccountManager _accountManager;

        public HomeController(IWebsiteService websiteService, IWebsiteManager websiteManager, IAccountManager accountManager)
        {
            _websiteService = websiteService;
            _websiteManager = websiteManager;
            _accountManager = accountManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetWebsite(string id)
        {
            var web = _websiteService.Get(id);
            //var x = web.EwhAccounts;
            return Json(web, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult AddWebsite()
        //{
        //    if (_websiteManager.CreateWebsite())
        //    {
        //        return Json(_websiteManager.EwhWebsiteAdded, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { Status= _websiteManager.EwhStatus, Ex = _websiteManager.EwhException, Msg = _websiteManager.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult CreateAccount()
        //{
        //    if (_accountManager.CreateAccount())
        //    {
        //        return Json(_accountManager.EwhAccountAdded, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { Status = _accountManager.EwhStatus.ToString(), Ex = _accountManager.EwhException, Msg = _accountManager.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult UpdateAccessLevel(UpdateAccountAccessLevelToWebsite model)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite("");//model.WebsiteId);
            if (ewhWebsite.UpdateAccessLevel(model))
            {
                return Json(ewhWebsite, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Status = ewhWebsite.EwhStatus.ToString(), Ex = ewhWebsite.EwhException, Msg = ewhWebsite.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddStagging(UpdateDeploymentEnvironmentToWebsite dto)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite("");// dto.WebsiteId);
            if (ewhWebsite.AddStagging(dto))
            {
                return Json(ewhWebsite, JsonRequestBehavior.AllowGet);
            }else
            {
                return Json(new { Status = ewhWebsite.EwhStatus.ToString(), Ex = ewhWebsite.EwhException, Msg = ewhWebsite.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RemoveStagging(UpdateDeploymentEnvironmentToWebsite dto)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite("");// dto.WebsiteId);
            if (ewhWebsite.RemoveStaging(dto.EnviromentId))
            {
                return Json(ewhWebsite, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = ewhWebsite.EwhStatus.ToString(), Ex = ewhWebsite.EwhException, Msg = ewhWebsite.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddProduction(UpdateDeploymentEnvironmentToWebsite dto)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite("");// dto.WebsiteId);
            if (ewhWebsite.AddProduction(dto))
            {
                return Json(ewhWebsite, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = ewhWebsite.EwhStatus.ToString(), Ex = ewhWebsite.EwhException, Msg = ewhWebsite.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RemoveProduction(UpdateDeploymentEnvironmentToWebsite dto)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite("");// dto.WebsiteId);
            if (ewhWebsite.RemoveProduction(dto.EnviromentId))
            {
                return Json(ewhWebsite, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = ewhWebsite.EwhStatus.ToString(), Ex = ewhWebsite.EwhException, Msg = ewhWebsite.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddWebsiteAccount(string wId, string uId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(wId);
            //if(ewhWebsite.AddAccount(new application.Entities.Dto.AddWebsiteAccountDto() { AccountId = uId, WebsiteId = wId, AccessLevels = new List<string>() { "dev", "test" }, WebsiteDisplayName = "My web" }))
            if (ewhWebsite.AddAccount(new application.Entities.Dto.AddWebsiteAccountDto() { AccountId = uId, AccessLevels = new List<string>() { "dev", "test" }, WebsiteDisplayName = "My web" }))
            {
                return Json(ewhWebsite.GetListAccount(), JsonRequestBehavior.AllowGet);
            }
            return Json(new { Status = _websiteManager.EwhStatus.ToString(), Ex = _websiteManager.EwhException, Msg = _websiteManager.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveWebsiteAccount(string wId, string uId)
        {
            var ewhWebsite = _websiteManager.GetEwhWebsite(wId);
            if (ewhWebsite.RemoveAccount(uId))
            {
                return Json(ewhWebsite.GetListAccount(), JsonRequestBehavior.AllowGet);
            }
            return Json(new { Status = _websiteManager.EwhStatus.ToString(), Ex = _websiteManager.EwhException, Msg = _websiteManager.EwhErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListWebsite()
        {
            var websites = _websiteManager.GetListEwhWebsite();
            return Json(websites, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListAccount()
        {
            return Json(_accountManager.GetListAccount(), JsonRequestBehavior.AllowGet);
        }
    }
}