using ew.application.Entities;
using ew.application.Services;
using ew.core.Enums;
using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Managers
{
    public interface IManagerFactory
    {
        AccountManager InitAccountManager();
        WebsiteManager InitWebsiteManager();
    }

    public class ManagerFactory : IManagerFactory
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly Lazy<IEntityFactory> _entityFactory;
        private readonly Lazy<IEwhMapper> _ewhMapper;

        public ManagerFactory(IAccountRepository accountRepository, IWebsiteRepository websiteRepository, Lazy<IEntityFactory> entityFactory, Lazy<IEwhMapper> ewhMapper)
        {
            _accountRepository = accountRepository;
            _websiteRepository = websiteRepository;
            _entityFactory = entityFactory;
            _ewhMapper = ewhMapper;
        }

        public AccountManager InitAccountManager()
        {
            return new AccountManager(_entityFactory, _websiteRepository, _accountRepository, _ewhMapper);
        }

        public WebsiteManager InitWebsiteManager()
        {
            return new WebsiteManager(_websiteRepository, _accountRepository, _ewhMapper, _entityFactory);
        }
    }
}
