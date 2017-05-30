using ew.common;
using ew.common.Entities;
using ew.common.Helper;
using ew.gitea_wrapper.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ew.gitea_wrapper
{
    public class EwhGitea: EwhEntityBase
    {
        public Res_ConfirmWebsiteDto WebsiteInfo { get; private set; }
        private string GiteaBaseUrl = "http://212.47.253.180:7002/";

        public bool ConfirmWebsite(ConfirmWebsiteDto dto)
        {
            EwhLogger.Common.Debug("Confirm website : " + JsonHelper.SerializeObject(dto));
            var _client = new RestClient(GiteaBaseUrl);
            var request = new RestRequest("confirm-website", Method.POST) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");
            request.AddBody(dto);
            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                EwhLogger.Common.Error("==> Success: ", JsonHelper.SerializeObject(response.Content));
                WebsiteInfo = JsonHelper.DeserializeObject<Res_ConfirmWebsiteDto>(response.Content);
                return true;
            }
            else
            {
                EwhLogger.Common.Error("==> Failed: ", JsonHelper.SerializeObject(response.ErrorException));
            }
            return false;
        }

    }
}
