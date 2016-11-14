using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Services
{
    public class AuthService
    {
        private readonly IAccountRepository _accountRepository;
        
        public AuthService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        

    }
}
