using ew.application.Entities;
using ew.application.Managers;
using ew.common.Entities;
using ew.common.Helper;
using ew.core.Enums;
using ew.core.Repositories;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Services
{
    public class AuthService : EwhEntityBase, IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEntityFactory _entityFactory;
        private readonly Lazy<IEwhMapper> _ewhMapper;
        private Account authorizedAccount;
        
        public AuthService(IAccountRepository accountRepository, Lazy<IEwhMapper> ewhMapper, IEntityFactory entityFactory)
        {
            _accountRepository = accountRepository;
            _entityFactory = entityFactory;
            this._ewhMapper = ewhMapper;
        }


        public bool CheckUserAuth(string username, string password)
        {
            var user = _accountRepository.GetByUsername(username);
            if (IsExits(user) && CheckPassword(user, password))
            {
                this.authorizedAccount = user;
                return true;
            };
            return false;
        }

        public EwhAccount AuthorizedAccount()
        {
            return _entityFactory.GetAccount(this.authorizedAccount);
        }

        private bool CheckPassword(Account account, string password)
        {
            if(!StringUtils.CheckSaltedHash(account.Password, account.PasswordSalt, password))
            {
                this.EwhStatus = core.Enums.GlobalStatus.Account_WrongPassword;
                return false;
            }
            return true;
        }

        private bool IsExits(Account account)
        {
            if (account == null)
            {
                this.EwhStatus = core.Enums.GlobalStatus.Account_Username_NotFound;
                return false;
            }
            return true;
        }

        private bool IsActive(Account account)
        {
            if(account.Status == AccountStatus.Active.ToString())
            {
                return true;
            }

            switch (account.Status)
            {
                case "Locked":
                    this.EwhStatus = GlobalStatus.Account_IsLocked;
                    break;
                case "Deleted":
                    this.EwhStatus = GlobalStatus.Account_IsDeleted;
                    break;
                
            }
            return false;
        }

    }
}
