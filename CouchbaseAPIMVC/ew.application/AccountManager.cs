using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.application.Services;
using ew.common.Entities;
using ew.core.Dtos;
using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application
{
    public class AccountManager : EwhEntityBase, IAccountManager
    {
        private readonly IAccountService _accountService;
        private readonly IWebsiteService _websiteService;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;

        private readonly IEwhMapper _ewhMapper;

        public AccountManager(IAccountService accountService, IWebsiteService websiteService, IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _accountService = accountService;
            _websiteService = websiteService;
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        #region properties
        public EwhAccount EwhAccountAdded { get; protected set; }
        #endregion

        public bool CreateAccount(AddAccountDto dto)
        {
            var ewhAccount = new EwhAccount(_accountService, _websiteService, _websiteRepository, _accountRepository, _ewhMapper);
            var check = false;
            if (ewhAccount.Create(dto))
            {
                check = true;
                EwhAccountAdded = ewhAccount;
            }
            SyncStatus(this, ewhAccount);
            return check;
        }

        public EwhAccount GetEwhAccount(string id)
        {
            var account = _accountRepository.Get(id);
            if (account == null)
            {
                EwhStatus = core.Enums.GlobalStatus.NotFound;
                return null;
            }
            return new EwhAccount(account,_accountService, _websiteService, _websiteRepository, _accountRepository, _ewhMapper);
        }


        public List<EwhAccount> GetListAccount(AccountQueryParams queryParams = null )
        {
            if (queryParams == null) queryParams = new AccountQueryParams();
            var query = _accountRepository.Find(queryParams);
            this.EwhCount = query.Count();
            query = query.Skip(queryParams.Offset).Take(queryParams.Limit);
            return _ewhMapper.ToEwhAccounts(query.ToList());
        }


    }
}
