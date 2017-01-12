using ew.application.Entities.Dto;
using ew.application.Helpers;
using ew.application.Services;
using ew.common.Entities;
using ew.common.Helper;
using ew.core;
using ew.core.Repositories;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities
{
    public class EwhAccount : EwhEntityBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IWebsiteService _websiteService;
        private readonly IEwhMapper _ewhMapper;
        //private readonly AuthService _authService;
        public EwhAccount(IAccountService accountService, IWebsiteService websiteService, IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _accountService = accountService;
            _websiteService = websiteService;

            _ewhMapper = ewhMapper;
            //_authService = authService;
        }

        public EwhAccount(Account account, IAccountService accountService, IWebsiteService websiteService, IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _accountService = accountService;
            _websiteService = websiteService;

            _ewhMapper = ewhMapper;
            _account = account;
            MapFrom(account);
        }

        public EwhAccount(string accountId, IAccountService accountService, IWebsiteService websiteService, IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _accountService = accountService;
            _websiteService = websiteService;

            _ewhMapper = ewhMapper;
            _account = _accountRepository.Get(accountId);
            MapFrom(_account);
        }



        #region properties
        public string AccountId { get; private set; }
        public string AccountType { get; set; }
        public string Password { get; private set; }
        public string PasswordSaft { get; private set; }
        [Required]
        public string UserName { get; set; }
        public string Status { get; set; }
        public AccountInfo Info { get; set; }
        public List<WebsitesAccessLevelOfAccount> Websites { get; set; }
        #endregion

        #region ext properties
        private Account _account;
        //private List<EwhWebsite> _ewhWebsites { get; set; }
        //public List<EwhWebsite> EwhWebsites
        //{
        //    get
        //    {
        //        if (_ewhWebsites == null) _ewhWebsites = _websiteService.GetListWebsite(this.Websites.Select(x => x.WebsiteId).ToList());
        //        return _ewhWebsites;
        //    }
        //    private set { _ewhWebsites = value; }
        //}
        #endregion

        #region public methods

        public List<EwhWebsite> GetListWebsite()
        {
            return _websiteService.GetListWebsite(this.Websites.Select(x => x.WebsiteId).ToList());
        }

        public bool IsExits()
        {
            if (!string.IsNullOrEmpty(AccountId))
            {
                return true;
            }
            EwhStatus = core.Enums.GlobalStatus.NotFound;
            return false;
        }

        public bool Create(AddAccountDto dto)
        {
            if (!ValidateHelper.Validate(dto, out ValidateResults))
            {
                EwhStatus = core.Enums.GlobalStatus.InvalidData;
                return false;
            }
            _ewhMapper.ToEntity(this, dto);
            this.PasswordSaft = StringUtils.CreateSalt(20);
            this.Password = StringUtils.GenerateSaltedHash(dto.Password, this.PasswordSaft);
            return Save();
        }

        public bool Save()
        {
            if (CheckValidModel() && (IsExits() || CheckIsIdentity()))
            {
                _accountRepository.AddOrUpdate(_ewhMapper.ToEntity(_account ?? new Account(), this));
                return true;
            }
            return false;
        }

        public bool UpdateInfo(AccountInfo info)
        {
            this.Info = info;
            return Save();
        }

        public bool ChangePassword(string password, string newpassword)
        {
            return true;
        }

        public bool ResetPassword()
        {
            this.PasswordSaft = StringUtils.CreateSalt(20);
            this.Password = StringUtils.GenerateSaltedHash("123456", this.PasswordSaft);
            Save();
            return true;
        }

        public bool RemoveWebsite(EwhWebsite website)
        {
            var webIdentity = this.Websites.FirstOrDefault(x => x.WebsiteId == website.WebsiteId);
            if (webIdentity != null)
            {
                this.Websites.Remove(webIdentity);
                return Save();
            }
            else
            {
                EwhStatus = core.Enums.GlobalStatus.NotFound;
                return false;
            }
        }
        #endregion


        #region private methods
        private void MapFrom(Account account)
        {
            this.AccountId = account.Id;
            this.UserName = account.UserName;
            this.AccountType = account.AccountType;
            this.Status = account.Status;
            this.Info = account.Info ?? new AccountInfo();
            this.Websites = account.Websites ?? new List<WebsitesAccessLevelOfAccount>();
            this.Password = account.Password;
            this.PasswordSaft = account.PasswordSalt;
        }

        private bool CheckValidModel()
        {
            //if (ValidateHelper.Validate(this, out ValidateResults))
            //{
            //    EwhStatus = core.Enums.GlobalStatus.InvalidData;
            //    return false;
            //}
            return true;
        }
        private bool CheckIsIdentity()
        {
            return CheckValidUserName();
        }
        public bool CheckValidUserName()
        {
            if (_accountRepository.IsExitsUserName(this.UserName))
            {
                base.EwhStatus = core.Enums.GlobalStatus.AlreadyExists;
                return false;
            }
            return true;
        }
        private bool CheckValidPassword()
        {
            return true;
        }
        #endregion
    }
}
