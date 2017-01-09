﻿using ew.application.Entities;
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
        }
    }

    public class WebsiteDetailDto: WebsiteInfoDto
    {
        public List<DeploymentEnvironment> Stagging { get; private set; }
        public List<DeploymentEnvironment> Production { get; private set; }
        public List<WebsiteAccountAccessLevel> Accounts { get; set; }

        public WebsiteDetailDto() { }

        public WebsiteDetailDto(EwhWebsite entity):base(entity)
        {
            this.Stagging = entity.Stagging;
            this.Production = entity.Production;
            this.Accounts = entity.Accounts;
        }
    }

    
    #endregion
}