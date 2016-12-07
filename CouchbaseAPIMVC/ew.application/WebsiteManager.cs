using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.application.Services;
using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application
{
    public class WebsiteManager : EwhEntityBase, IWebsiteManager
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IEwhMapper _ewhMapper;

        public WebsiteManager(IWebsiteRepository websiteRepository, IAccountRepository accountRepository, IEwhMapper ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        public EwhWebsite EwhWebsiteAdded { get; private set; }

        public bool CreateWebsite(CreateWebsiteDto dto)
        {
            var ewhWebsite = new EwhWebsite(_websiteRepository, _accountRepository, _ewhMapper);
            _ewhMapper.ToEntity(ewhWebsite, dto);
            var check = false;
            if (ewhWebsite.Create())
            {
                check = true;
                EwhWebsiteAdded = ewhWebsite;
            }
            SyncStatus(this, ewhWebsite);
            return check;
        }
        
        public EwhWebsite GetEwhWebsite(string id)
        {
            var website = _websiteRepository.Get(id);
            if (website == null)
            {
                EwhStatus = core.Enums.GlobalStatus.NotFound;
                return null;
            }
            return new EwhWebsite(website, _websiteRepository, _accountRepository, _ewhMapper);
        }

        public List<EwhWebsite> GetListEwhWebsite()
        {
            return _ewhMapper.ToEwhWebsites(_websiteRepository.FindAll().ToList());
        }
    }
}
