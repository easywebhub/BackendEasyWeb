using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.application.Managers;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly Lazy<IEntityFactory> _entityFactory;
        private IEntityFactory entityFactory { get { return _entityFactory.Value; } }

        private readonly Lazy<IEwhMapper> _ewhMapper;
        private IEwhMapper ewhMapper { get { return _ewhMapper.Value; } }

        public AccountManager(Lazy<IEntityFactory> entityFactory, IWebsiteRepository websiteRepository, IAccountRepository accountRepository, Lazy<IEwhMapper> ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _entityFactory = entityFactory;
            _ewhMapper = ewhMapper;
        }

        #region properties
        public EwhAccount EwhAccountAdded { get; protected set; }
        #endregion

        public bool CreateAccount(AddAccountDto dto)
        {
            var ewhAccount = entityFactory.InitAccount();
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
            return entityFactory.GetAccount(account);
        }


        public List<EwhAccount> GetListAccount(AccountQueryParams queryParams = null )
        {
            if (queryParams == null) queryParams = new AccountQueryParams();
            var query = _accountRepository.Find(queryParams);
            this.EwhCount = query.Count();
            query = query.Skip(queryParams.Offset).Take(queryParams.Limit);
            return ewhMapper.ToEwhAccounts(query.ToList());
        }

        public bool CreateAccount(EwhAccount account)
        {
            return account.Create();
        }

        public bool UpdateAccount(EwhAccount account)
        {
            if (account.Save())
            {
                account.SelfSync();
                return true;
            }
            return false;
        }

        public EwhAccount InitEwhAccount()
        {
            return entityFactory.InitAccount();
        }
    }
}
