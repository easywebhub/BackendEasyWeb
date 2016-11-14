using ew.application.Entities;
using ew.core;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ew.application.Entities.Dto;
using ew.core.Dto;

namespace ew.application.Services
{
    public class EwhMapper : IEwhMapper
    {
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IWebsiteService> _websiteService;

        public EwhMapper(Lazy<IAccountService> accountService, Lazy<IWebsiteService> websiteService)
        {
            _accountService = accountService;
            _websiteService = websiteService;
        }

        public EwhAccount ToEwhAccount(Account account)
        {
            return new EwhAccount(account, _accountService as IAccountService);
        }

        public void ToEntity(EwhAccount ewhAccount, Account account)
        {
            account.AccountType = ewhAccount.AccountType;
            account.UserName = ewhAccount.UserName;
            account.Status = ewhAccount.Status;
            account.Websites = ewhAccount.Websites;
            account.Info = ewhAccount.Info;
        }

        public List<EwhAccount> ToEwhAccounts(List<Account> listAccount)
        {
            return listAccount.Select(x => new EwhAccount(x, _accountService as IAccountService)).ToList();
        }

        public List<EwhWebsite> ToEwhWebsites(List<Website> listWebsite)
        {
            return listWebsite.Select(x => new EwhWebsite(x, _accountService as IAccountService)).ToList();
        }

        public AddAccountDto ToEntity(AddAccountDto dto, EwhAccount ewhAccount)
        {
            dto.AccountType = ewhAccount.AccountType;

            return dto;
        }
        public EwhAccount ToEntity(EwhAccount ewhAccount, AddAccountDto account)
        {
            ewhAccount.AccountType = account.AccountType;
            ewhAccount.UserName = account.UserName;
            ewhAccount.Info = account.Info;

            return ewhAccount;
        }

        public WebsiteIdentity ToEntity(WebsiteIdentity entity, AddWebsiteAccountDto dto)
        {
            entity.DisplayName = dto.WebsiteDisplayName;
            entity.WebsiteId = dto.WebsiteId;
            return entity;
        }
        public WebsiteAccountAccessLevel ToEntity(WebsiteAccountAccessLevel entity, AddWebsiteAccountDto dto)
        {
            entity.AccountId = dto.AccountId;
            entity.AccessLevels = dto.AccessLevels;
            return entity;
        }

        EwhAccount IEwhMapper.ToEntity(EwhAccount ewhAccount, Account account)
        {
            throw new NotImplementedException();
        }

        public Account ToEntity(Account account, EwhAccount ewhAccount)
        {
            account.AccountType = ewhAccount.AccountType;
            account.Info = ewhAccount.Info;
            account.Password = ewhAccount.Password;
            account.PasswordSalt = ewhAccount.PasswordSaft;
            account.Status = ewhAccount.Status;
            account.UserName = ewhAccount.UserName;
            account.Websites = ewhAccount.Websites;

            return account;
        }

        public Website ToEntity(Website website, EwhWebsite ewhWebsite)
        {
            website.DisplayName = ewhWebsite.DisplayName;
            website.Name = ewhWebsite.Name;
            website.Url = ewhWebsite.Url;
            website.Stagging = ewhWebsite.Stagging;
            website.Production = ewhWebsite.Production;
            website.Accounts = ewhWebsite.Accounts;
            return website;
        }

        public DeploymentEnviromentModel ToEntity(DeploymentEnviromentModel model, UpdateDeploymentEnvironmentToWebsite dto)
        {
            model.Git = dto.Git;
            model.HostingFee = dto.HostingFee;
            model.IsDefault = dto.IsDefault;
            model.Name = dto.Name;
            model.Url = dto.Url;
            return model;
        }
        
    }
}
