using ew.application.Entities.Dto;
using ew.application.Helpers;
using ew.application.Services;
using ew.common.Entities;
using ew.core;
using ew.core.Dto;
using ew.core.Dtos;
using ew.core.Enums;
using ew.core.Repositories;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities
{
    public class EwhWebsite : EwhEntityBase
    {
        private readonly IAccountService _accountService;
        private readonly IWebsiteService _websiteService;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IEwhMapper _ewhMapper;
        public EwhWebsite(IAccountService accountService, IEwhMapper ewhMapper)
        {
            _accountService = accountService;
            _ewhMapper = ewhMapper;
            _website = new Website();
            MapFrom(_website);
        }

        public EwhWebsite(IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _website = new Website();
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        public EwhWebsite(Website website, IAccountService accountService)
        {
            _accountService = accountService;
            _website = website;
            MapFrom(website);
        }

        public EwhWebsite(Website website, IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper) : this(websiteRepository, accountRepository, ewhMapper)
        {
            _website = website;
            MapFrom(website);
        }

        #region properties
        private Website _website;
        public string WebsiteId { get; private set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string WebTemplateId { get; set; }
        public string Source { get; set; }
        public string Git { get; set; }
        public string WebsiteType { get; set; }
        public List<DeploymentEnvironment> Stagging { get; private set; }
        public List<DeploymentEnvironment> Production { get; private set; }
        public List<AccountsAccessLevelOfWebsite> Accounts { get; set; }

        public string RepositoryName { get { return this.Name; } }

        //private List<EwhAccount> _ewhAccounts { get; set; }
        //public List<EwhAccount> EwhAccounts
        //{
        //    get
        //    {
        //        if (_ewhAccounts == null) _ewhAccounts = _accountService.GetListAccount(this.Accounts.Select(x => x.AccountId).ToList());
        //        return _ewhAccounts;
        //    }
        //    set { _ewhAccounts = value; }
        //}

        public List<EwhAccount> GetListAccount()
        {
            var listAccountId = this.Accounts.Select(x => x.AccountId).ToList();
            return _ewhMapper.ToEwhAccounts(_accountRepository.GetList(listAccountId));
        }

        #endregion

        #region public methods
        public bool IsExits()
        {
            if (!string.IsNullOrEmpty(WebsiteId))
            {
                return true;
            }
            EwhStatus = core.Enums.GlobalStatus.NotFound;
            return false;
        }

        /// <summary>
        /// get account as owner of website
        /// </summary>
        /// <returns>id of account</returns>
        public string GetOwner()
        {
            if (!IsExits())
            {
                var owner = this.Accounts.FirstOrDefault(x => x.AccessLevels.Contains(AccessLevels.owner.ToString()));
                if (owner != null)
                {
                    return owner.AccountId;
                }
            }
            return string.Empty;
        }

        

        public bool Save()
        {
            _websiteRepository.AddOrUpdate(_ewhMapper.ToEntity(_website, this));
            WebsiteId = _website.Id;
            return true;
        }

        public bool Create()
        {
            _websiteRepository.AddOrUpdate(_ewhMapper.ToEntity(_website, this));
            WebsiteId = _website.Id;
            if(_website.Accounts!=null && _website.Accounts.Any())
            {
                var accList = new AccountsAccessLevelOfWebsite[_website.Accounts.Count];
                _website.Accounts.CopyTo(accList);
                foreach(var acc in accList)
                {
                    var addWebsiteAccount = new AddWebsiteAccountDto() { AccessLevels = acc.AccessLevels, AccountId = acc.AccountId };
                    this.AddAccount(addWebsiteAccount);
                }
            }
            return true;
        }

        public bool AddAccount(AddWebsiteAccountDto dto)
        {
            if (!IsExits()) return false;

            if (!ValidateHelper.Validate(dto, out ValidateResults))
            {
                EwhStatus = core.Enums.GlobalStatus.InvalidData;
                return false;
            }
            var account = _accountRepository.Get(dto.AccountId);
            if (account == null)
            {
                EwhStatus = core.Enums.GlobalStatus.Account_NotFound;
                return false;
            }

            var coreDto = new core.Dtos.AddWebsiteAccountModel() { Account = account, Website = _website, AccessLevels = dto.AccessLevels, WebsiteDisplayName = _website.DisplayName };
            _websiteRepository.AddAccount(coreDto);
            _accountRepository.AddWebsite(coreDto);

            return true;
        }

        public bool RemoveAccount(string accountId)
        {
            if (!IsExits()) return false;

            var account = _accountRepository.Get(accountId);
            if (account == null)
            {
                EwhStatus = core.Enums.GlobalStatus.Account_NotFound;
                return false;
            }
            var removeAccountDto = new RemoveWebsiteAccountModel() { Account = account, Website = _website };
            _websiteRepository.RemoveAccount(removeAccountDto);
            _accountRepository.RemoveWebsite(removeAccountDto);
            return true;
        }

        public bool UpdateAccessLevel(UpdateAccountAccessLevelToWebsite dto)
        {
            if (!IsExits()) return false;
            var websiteAccount = this.Accounts.FirstOrDefault(x => x.AccountId == dto.AccountId);
            if (websiteAccount == null)
            {
                EwhStatus = core.Enums.GlobalStatus.NotFound;
                return false;
            }
            _website.Accounts.Remove(websiteAccount);
            _website.Accounts.Add(new AccountsAccessLevelOfWebsite() { AccountId = dto.AccountId, AccessLevels = dto.AccessLevels });
            _websiteRepository.AddOrUpdate(_website);
            return true;
        }
        
        public bool AddStagging(UpdateDeploymentEnvironmentToWebsite dto)
        {
            if (!IsExits()) return false;
            var model = new DeploymentEnviromentModel() { Website = _website };
            if(_websiteRepository.AddOrUpdateStaging(_ewhMapper.ToEntity(model, dto))){
                return true;
            }
            return false;
        }

        public bool AddProduction(UpdateDeploymentEnvironmentToWebsite dto)
        {

            if (!IsExits()) return false;
            var model = new DeploymentEnviromentModel() { Website = _website };
            if (_websiteRepository.AddOrUpdateProduction(_ewhMapper.ToEntity(model, dto))){
                return true;
            }
            return false;
        }

        public bool RemoveStaging(string deId)
        {
            if (!IsExits()) return false;
            var model = new DeploymentEnviromentModel() { Website = _website, EnviromentId = deId };
            if (_websiteRepository.RemoveStaging(model))
            {
                return true;
            }
            return false;
        }

        public bool RemoveProduction(string deId)
        {
            if (!IsExits()) return false;
            var model = new DeploymentEnviromentModel() { Website = _website, EnviromentId = deId };
            if (_websiteRepository.RemoveProduction(model))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region methods
        private void MapFrom(Website website)
        {
            WebsiteId = website.Id;
            Name = website.Name;
            DisplayName = website.DisplayName;
            Url = website.Url;
            Stagging = website.Stagging ?? new List<DeploymentEnvironment>();
            Production = website.Production ?? new List<DeploymentEnvironment>();
            Accounts = website.Accounts ?? new List<AccountsAccessLevelOfWebsite>();
            this.WebTemplateId = website.WebTemplateId;
            this.Source = website.Source;
            this.Git = website.Git;
            this.WebsiteType = website.WebsiteType;
        }

        #endregion


    }
}
