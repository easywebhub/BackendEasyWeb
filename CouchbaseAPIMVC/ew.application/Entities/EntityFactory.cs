using ew.application.Entities;
using ew.application.Services;
using ew.core;
using ew.core.Enums;
using ew.core.Repositories;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Managers
{
    public interface IEntityFactory
    {
        EwhAccount InitAccount();
        EwhAccount GetAccount(string id);
        EwhAccount GetAccount(Account account);
        EwhWebsite InitWebsite();
        EwhWebsite GetWebsite(string id);
        EwhWebsite GetWebsite(Website website);
        EwhAction InitAction();
        EwhAction InitAction(ActionCodes action);
    }

    public class EntityFactory : IEntityFactory
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly Lazy<IWebsiteManager> _websiteManager;
        private IWebsiteManager websiteManager { get { return _websiteManager.Value; } }
        private readonly Lazy<IEwhMapper> _ewhMapper;
        private IEwhMapper ewhMapper { get { return _ewhMapper.Value; } }
        private readonly Lazy<IEntityFactory> _entityFactory;

        public EntityFactory(IAccountRepository accountRepository, IWebsiteRepository websiteRepository, Lazy<IEwhMapper> ewhMapper, Lazy<IWebsiteManager> websiteManager, Lazy<IEntityFactory> entityFactory)
        {
            _accountRepository = accountRepository;
            _websiteRepository = websiteRepository;
            _websiteManager = websiteManager;
            _ewhMapper = ewhMapper;
            _entityFactory = entityFactory;
        }

        public EwhAccount GetAccount(Account account)
        {
            return new EwhAccount(account, _websiteManager, _websiteRepository, _accountRepository, _ewhMapper);
        }

        public EwhAccount GetAccount(string id)
        {
            return new EwhAccount(id, _websiteManager, _websiteRepository, _accountRepository, _ewhMapper);
        }

        public EwhWebsite GetWebsite(string id)
        {
            return new EwhWebsite(id, _websiteRepository, _accountRepository, _ewhMapper, _entityFactory);
        }

        public EwhWebsite GetWebsite(Website website)
        {
            return new EwhWebsite(website, _websiteRepository, _accountRepository, _ewhMapper, _entityFactory);
        }

        public EwhAccount InitAccount()
        {
            return new EwhAccount(_websiteManager, _websiteRepository, _accountRepository, _ewhMapper);
        }

        public EwhAction InitAction()
        {
            throw new NotImplementedException();
        }

        public EwhAction InitAction(ActionCodes action)
        {
            throw new NotImplementedException();
        }

        public EwhWebsite InitWebsite()
        {
            return new EwhWebsite(_websiteRepository, _accountRepository, _ewhMapper, _entityFactory);
        }
    }
}
