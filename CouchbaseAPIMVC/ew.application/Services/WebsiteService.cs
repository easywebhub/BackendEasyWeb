using ew.application.Entities;
using ew.core;
using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEwhMapper _ewhMapper;
        private readonly IAccountService _accountService;

        public WebsiteService(IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IAccountService accountService, IEwhMapper ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _accountService = accountService;
            _ewhMapper = ewhMapper;
        }

        public EwhWebsite Get(string id)
        {
            return new EwhWebsite(_websiteRepository.Get(id), _websiteRepository, _accountRepository, _ewhMapper);
        }

        public List<EwhWebsite> GetListWebsite(List<string> listWebsiteId)
        {
            return _ewhMapper.ToEwhWebsites(_websiteRepository.GetList(listWebsiteId));
        }
        
        
        
    }
}
