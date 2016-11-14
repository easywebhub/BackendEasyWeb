using ew.application.Entities;
using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEwhMapper _ewhMapper;

        public AccountService(IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        public List<EwhAccount> GetListAccount(List<string> listAccountId)
        {
            return _ewhMapper.ToEwhAccounts(_accountRepository.GetList(listAccountId));
        }

        public EwhAccount GetByUserName(string username)
        {
            return _ewhMapper.ToEwhAccount(_accountRepository.FindAll().FirstOrDefault(x => x.UserName == username));
        }

        public string Save(EwhAccount account)
        {
            var acc = _accountRepository.Get(account.AccountId);
            _ewhMapper.ToEntity(acc ?? new core.Users.Account(), account);
            _accountRepository.AddOrUpdate(acc);
            return acc.Id;
        }

        public bool IsExitsUserName(string username)
        {
            return _accountRepository.FindAll().Any(x => x.UserName == username);
        }
    }
}
