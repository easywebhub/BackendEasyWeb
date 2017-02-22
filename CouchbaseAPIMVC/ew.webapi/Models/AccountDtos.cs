using ew.application.Entities;
using ew.core;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ew.webapi.Models
{
    public class AccountInfoDto
    {
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public AccountInfo Info { get; set; }

        public AccountInfoDto()
        {

        }

        public AccountInfoDto(EwhAccount entity)
        {
            this.AccountId = entity.AccountId;
            this.AccountType = entity.AccountType;
            this.UserName = entity.UserName;
            this.Status = entity.Status;
            this.Info = entity.Info;
        }
    }

    public class AccountInfoCanAccessWebsiteDto: AccountInfoDto
    {
        public List<string> AccessLevels { get; set; }

        public AccountInfoCanAccessWebsiteDto(): base() { }

        public AccountInfoCanAccessWebsiteDto(EwhAccount entity, string websiteId): base(entity)
        {
            this.AccessLevels = entity.Websites.Where(x => x.WebsiteId == websiteId).Select(x => x.AccessLevels).FirstOrDefault();
        }
    }

    public class AccountDetailDto: AccountInfoDto
    {
        public List<WebsitesAccessLevelOfAccount> Websites { get; set; }

        public AccountDetailDto() { }

        public AccountDetailDto(EwhAccount entity): base(entity)
        {
            this.Websites = entity.Websites;
        }

        public EwhAccount ToEntity(EwhAccount entity)
        {
            entity.AccountType = this.AccountType;
            entity.Info = this.Info;
            entity.Status = this.Status;
            entity.Websites = this.Websites;

            return entity;
        }
    }
}