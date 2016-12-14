using ew.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Linq;
using ew.core.Repositories;
using ew.core.Dtos;
using ew.core.Dto;
using ew.core.Enums;

namespace ew.infrastructure.Repositories
{
    public class WebsiteRepository : GenericRepository<Website>, IWebsiteRepository
    {
        public WebsiteRepository(IBucket bucket, IBucketContext context) : base(bucket, context)
        {
        }

        public bool AddAccount(AddWebsiteAccountModel dto)
        {
            //var website = Get(dto.Website.Id);
            var website = dto.Website;
            if (website == null) return false;
            if (website.Accounts.Any(x => x.AccountId == dto.Account.Id)) return true;
            if (website.Accounts == null) website.Accounts = new List<WebsiteAccountAccessLevel>();
            website.Accounts.Add(new WebsiteAccountAccessLevel() { AccountId = dto.Account.Id, AccessLevels = dto.AccessLevels });
            this.AddOrUpdate(website);
            return true;
        }

        public bool RemoveAccount(RemoveWebsiteAccountModel dto)
        {
            //var website = Get(dto.Website.Id);
            var website = dto.Website;
            if (website == null) return false;
            var webAccount = website.Accounts != null ? website.Accounts.FirstOrDefault(x => x.AccountId == dto.Account.Id) : null;
            if (webAccount == null) return false;
            website.Accounts.Remove(webAccount);
            this.AddOrUpdate(website);
            return true;
        }

        public bool AddOrUpdateStaging(DeploymentEnviromentModel dto)
        {
            var website = dto.Website;
            if (website.Stagging == null) website.Stagging = new List<DeploymentEnvironment>();
            var websiteEnviroment = website.Stagging.FirstOrDefault(x => x.Id == dto.EnviromentId);
            if (websiteEnviroment != null)
            {
                website.Stagging.Remove(websiteEnviroment);
            }else
            {
                websiteEnviroment = new DeploymentEnvironment();
            }
            if (string.IsNullOrEmpty(websiteEnviroment.Id)) websiteEnviroment.Id = Guid.NewGuid().ToString();
            websiteEnviroment.Git = dto.Git;
            websiteEnviroment.Url = dto.Url;
            websiteEnviroment.HostingFee = dto.HostingFee;
            websiteEnviroment.Name = dto.Name;
            websiteEnviroment.IsDefault = dto.IsDefault;
            website.Stagging.Add(websiteEnviroment);

            this.AddOrUpdate(website);
            return true;
        }

        public bool RemoveStaging(DeploymentEnviromentModel dto)
        {
            var website = dto.Website;
            if (website.Stagging == null) website.Stagging = new List<DeploymentEnvironment>();
            var websiteEnviroment = website.Stagging.FirstOrDefault(x => x.Id == dto.EnviromentId);
            if (websiteEnviroment != null)
            {
                website.Stagging.Remove(websiteEnviroment);
                this.AddOrUpdate(website);
                return true;
            }
            return false;
        }

        public bool AddOrUpdateProduction(DeploymentEnviromentModel dto)
        {
            var website = dto.Website;
            if (website.Production == null) website.Production = new List<DeploymentEnvironment>();
            var websiteEnviroment = website.Production.FirstOrDefault(x => x.Id == dto.EnviromentId);
            if (websiteEnviroment != null)
            {
                website.Production.Remove(websiteEnviroment);
            }
            else
            {
                websiteEnviroment = new DeploymentEnvironment();
            }
            if (string.IsNullOrEmpty(websiteEnviroment.Id)) websiteEnviroment.Id = Guid.NewGuid().ToString();
            websiteEnviroment.Git = dto.Git;
            websiteEnviroment.Url = dto.Url;
            websiteEnviroment.HostingFee = dto.HostingFee;
            websiteEnviroment.Name = dto.Name;
            websiteEnviroment.IsDefault = dto.IsDefault;
            website.Production.Add(websiteEnviroment);

            this.AddOrUpdate(website);
            return true;
        }

        public bool RemoveProduction(DeploymentEnviromentModel dto)
        {
            var website = dto.Website;
            if (website.Production == null) website.Production = new List<DeploymentEnvironment>();
            var websiteEnviroment = website.Production.FirstOrDefault(x => x.Id == dto.EnviromentId);
            if (websiteEnviroment != null)
            {
                website.Production.Remove(websiteEnviroment);
                this.AddOrUpdate(website);
                return true;
            }
            return false;
        }

        #region private methods
        private DeploymentEnvironment GetDeploymentEnviroment(Website website, string id, string type)
        {
            if (type == DeploymentEnviromentTypes.Staging.ToString())
            {
                return website.Stagging != null ? website.Stagging.FirstOrDefault(x => x.Id == id) : null;
            }
            return website.Production != null ? website.Production.FirstOrDefault(x => x.Id == id) : null;
        }

        
        #endregion
    }
}
