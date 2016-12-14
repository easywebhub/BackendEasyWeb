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
        public string AccountId { get; private set; }
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

    public class AccountDetailDto: AccountInfoDto
    {
        public List<WebsiteIdentity> Websites { get; set; }

        public AccountDetailDto() { }

        public AccountDetailDto(EwhAccount entity): base(entity)
        {
            this.Websites = entity.Websites;
        }
    }
}