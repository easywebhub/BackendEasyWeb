using ew.cloudflare_wrapper.Models;
using ew.common;
using ew.common.Entities;
using ew.common.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ew.cloudflare_wrapper
{
    public class CloudflareManager : EwhEntityBase
    {
        public DNSRecord DNSRecordAdded;
        public string CloudflareBaseUrl = "https://api.cloudflare.com/";

        public bool CreateDNSRecord(string zoneId, UpdateDNSRecordDto dto)
        {
            //zones/:zone_identifier/dns_records
            var _client = new RestClient(CloudflareBaseUrl);
            var request = new RestRequest("zones/" + zoneId + "/dns_records", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(dto);
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");

            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var apiResult = JsonHelper.DeserializeObject<CloudflareApiResult<DNSRecord>>(response.Content);
                if (apiResult.success)
                {
                    DNSRecordAdded = apiResult.result;
                    return true;
                }
                else
                {
                    this.EwhErrorMessage = JsonHelper.SerializeObject(apiResult.errors);
                    EwhLogger.Common.Error(string.Format("CREATE_DNS_ERROR: {0}"), apiResult.errors);
                }

            }
            else
            {
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return false;
        }

        public bool UpdateDNSRecord(string zoneId, string dnsRecordId, UpdateDNSRecordDto dto)
        {
            //PUT / zones /:zone_identifier / dns_records /:identifier
            var _client = new RestClient(CloudflareBaseUrl);
            var request = new RestRequest(string.Format("zones/{0}/dns_records/{1}", zoneId, dnsRecordId), Method.PUT) { RequestFormat = DataFormat.Json };
            request.AddBody(dto);
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");

            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var apiResult = JsonHelper.DeserializeObject<CloudflareApiResult<DNSRecord>>(response.Content);
                if (apiResult.success)
                {
                    DNSRecordAdded = apiResult.result;
                    return true;
                }
                else
                {
                    this.EwhErrorMessage = JsonHelper.SerializeObject(apiResult.errors);
                    EwhLogger.Common.Error(string.Format("CREATE_DNS_ERROR: {0}"), apiResult.errors);
                }

            }
            else
            {
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return false;
        }

        public bool DeleteDNSRecord(string zoneId, string dnsRecordId)
        {
            //DELETE / zones /:zone_identifier / dns_records /:identifier
            var _client = new RestClient(CloudflareBaseUrl);
            var request = new RestRequest(string.Format("zones/{0}/dns_records/{1}", zoneId, dnsRecordId), Method.DELETE) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Authorization", "06272372527cf531fa0535ccbb33faf0fa2a2d9f");

            var response = _client.Execute(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var apiResult = JsonHelper.DeserializeObject<CloudflareApiResult<object>>(response.Content);
                if (apiResult.success)
                {
                    return true;
                }
                else
                {
                    this.EwhErrorMessage = JsonHelper.SerializeObject(apiResult.errors);
                    EwhLogger.Common.Error(string.Format("CREATE_DNS_ERROR: {0}"), apiResult.errors);
                }
            }
            else
            {
                this.EwhErrorMessage = response.ErrorMessage;
                this.EwhException = response.ErrorException;
            }
            return false;
        }
    }
}
