using ew.application.Entities;
using ew.application.Services;
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
        private readonly IEwhMapper _ewhMapper;

        public AccountManager(IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        #region properties
        public EwhAccount EwhAccountAdded { get; protected set; }
        #endregion

        public bool CreateAccount()
        {
            var ewhAccount = new EwhAccount(_websiteRepository, _accountRepository, _ewhMapper);
            var info = new core.Users.AccountInfo() { Address = "", Age = "28", Name = "Thanh", Sex = "Nam" };
            var check = false;
            if (ewhAccount.Add(new Entities.Dto.AddAccountDto() { AccountType = "member", Info = info, Password = "@123456", UserName = "thanhtd01" }))
            {
                check = true;
                EwhAccountAdded = ewhAccount;
            }
            SyncStatus(this, ewhAccount);
            return check;
        }

        public List<EwhAccount> GetListAccount()
        {
            return _ewhMapper.ToEwhAccounts(_accountRepository.FindAll().ToList());
        }
    }
}
