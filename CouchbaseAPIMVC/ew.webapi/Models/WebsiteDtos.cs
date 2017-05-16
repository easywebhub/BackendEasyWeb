using ew.application.Entities;
using ew.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ew.webapi.Models
{
    #region query
    public class WebsiteInfoDto
    {
        public string WebsiteId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string WebTemplateId { get; set; }
        public string Source { get; set; }
        public string WebsiteType { get; set; }
        public string Git { get; set; }
        public bool Confirmed { get { return !string.IsNullOrEmpty(this.Git) && !string.IsNullOrEmpty(this.Source); } set { } }
        public DateTime CreateDate { get; set; }
        public string RepositoryName { get; set; }

        public WebsiteInfoDto() { }

        public WebsiteInfoDto(EwhWebsite entity)
        {
            this.WebsiteId = entity.WebsiteId;
            this.Name = entity.Name;
            this.DisplayName = entity.DisplayName;
            this.Url = entity.Url;
            this.WebTemplateId = entity.WebTemplateId;
            this.WebsiteType = entity.WebsiteType;
            this.Source = entity.Source;
            this.Git = entity.Git;
            this.CreateDate = entity.CreatedDate;
            this.RepositoryName = entity.RepositoryName;
        }
    }

    public class NyWebsiteInfoDto: WebsiteInfoDto
    {
        public List<string> AccessLevels { get; set; }

        public NyWebsiteInfoDto(): base()
        {
        }

        public NyWebsiteInfoDto(EwhWebsite entity, string userId): base(entity)
        {
            this.AccessLevels = entity.Accounts.Where(x => x.AccountId == userId).Select(x => x.AccessLevels).FirstOrDefault();
        }
    }

    public class WebsiteDetailDto: WebsiteInfoDto
    {
        public List<DeploymentEnvironment> Stagging { get; set; }
        public List<DeploymentEnvironment> Production { get; set; }
        public List<AccountsAccessLevelOfWebsite> Accounts { get; set; }

        public WebsiteDetailDto() { }

        public WebsiteDetailDto(EwhWebsite entity):base(entity)
        {
            this.Stagging = entity.Stagging;
            this.Production = entity.Production;
            this.Accounts = entity.Accounts;
        }

        public EwhWebsite ToEntity(EwhWebsite entity)
        {
            entity.WebsiteId = this.WebsiteId;
            entity.Name = this.Name;
            entity.DisplayName = this.DisplayName;
            entity.Url = this.Url;
            entity.WebTemplateId = this.WebTemplateId;
            entity.WebsiteType = this.WebsiteType;
            entity.Source = this.Source;
            entity.Git = this.Git;
            
            entity.Accounts = this.Accounts;
            entity.Stagging = this.Stagging;
            entity.Production = this.Production;
            return entity;
        }
    }

    
    #endregion
}