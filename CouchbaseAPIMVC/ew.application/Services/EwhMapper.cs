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
using ew.core.Repositories;

namespace ew.application.Services
{
    public class EwhMapper : IEwhMapper
    {
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IWebsiteService> _websiteService;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;

        public EwhMapper(Lazy<IAccountService> accountService, Lazy<IWebsiteService> websiteService)
        {
            _accountService = accountService;
            _websiteService = websiteService;
        }

        public EwhAccount ToEwhAccount(Account account)
        {
            return new EwhAccount(account, _accountService as IAccountService, _websiteService as IWebsiteService, _websiteRepository, _accountRepository, this);
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
            return listAccount.Select(x => new EwhAccount(x, _accountService as IAccountService, _websiteService as IWebsiteService, _websiteRepository, _accountRepository, this)).ToList();
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
            //entity.WebsiteId = dto.WebsiteId;
            return entity;
        }
        public AccountsAccessLevelOfWebsite ToEntity(AccountsAccessLevelOfWebsite entity, AddWebsiteAccountDto dto)
        {
            entity.AccountId = dto.AccountId;
            entity.AccessLevels = dto.AccessLevels;
            
            return entity;
        }

        EwhAccount IEwhMapper.ToEntity(EwhAccount ewhAccount, Account account)
        {
            ewhAccount.AccountType = account.AccountType;
            ewhAccount.UserName = account.UserName;
            ewhAccount.Websites = account.Websites;
            ewhAccount.Info = account.Info;

            return ewhAccount;
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
            website.WebTemplateId = ewhWebsite.WebTemplateId;
            website.WebsiteType = ewhWebsite.WebsiteType;
            website.Source = ewhWebsite.Source;
            website.Git = ewhWebsite.Git;

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

        public EwhWebsite ToEntity(EwhWebsite ewhWebsite, CreateWebsiteDto dto)
        {
            ewhWebsite.DisplayName = dto.DisplayName;
            ewhWebsite.Url = dto.Url;
            ewhWebsite.Name = dto.Name;

            var listWebsiteAccountAccessLevel = new List<AccountsAccessLevelOfWebsite>();
            if (dto.Accounts != null)
                foreach (var item in dto.Accounts)
                {
                    var waal = this.ToEntity(new AccountsAccessLevelOfWebsite(), item);
                    listWebsiteAccountAccessLevel.Add(waal);
                }
            ewhWebsite.Accounts = listWebsiteAccountAccessLevel;
            return ewhWebsite;
        }
    }
}
