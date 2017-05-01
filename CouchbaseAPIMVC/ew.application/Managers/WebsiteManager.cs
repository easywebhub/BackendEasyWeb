using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.application.Services;
using ew.common.Entities;
using ew.core.Enums;
using ew.core.Repositories;
using ew.core.Users;
using ew.gogs_wrapper;
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
        private readonly Lazy<IEwhMapper> _ewhMapper;
        private IEwhMapper ewhMapper { get { return _ewhMapper.Value; } }

        public WebsiteManager(IWebsiteRepository websiteRepository, IAccountRepository accountRepository, Lazy<IEwhMapper> ewhMapper)
        {
            _websiteRepository = websiteRepository;
            _accountRepository = accountRepository;
            _ewhMapper = ewhMapper;
        }

        public EwhWebsite EwhWebsiteAdded { get; private set; }

        public bool CreateWebsite(CreateWebsiteDto dto)
        {
            var ewhWebsite = new EwhWebsite(_websiteRepository, _accountRepository, _ewhMapper);
            ewhMapper.ToEntity(ewhWebsite, dto);
            ewhWebsite.WebsiteType = WebsiteTypes.Free.ToString();
            var check = false;
            // create website
            if (ewhWebsite.Create())
            {
                check = true;
                ewhWebsite.InitGogSource();
                EwhWebsiteAdded = ewhWebsite;
            }
            SyncStatus(this, ewhWebsite);
            return check;
        }

        private bool CheckValidWebsite(EwhWebsite website)
        {
            var owner = website.Accounts.FirstOrDefault(x => x.AccessLevels.Contains(AccessLevels.Owner.ToString()));
            Account accountAsOwner;
            if (owner == null)
            {
                this.EwhStatus = GlobalStatus.HaveNoAnOwner;
                return false;
            }
            return true;
        }

        public bool CreateWebsite(EwhWebsite ewhWebsite)
        {
            if (!CheckValidWebsite(ewhWebsite)) return false;
            ewhWebsite.Create();
            return true;
        }

        public bool UpdateWebsite(EwhWebsite website)
        {
            if (!CheckValidWebsite(website)) return false;
            website.Save();
            website.SelfSync();
            return true;
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
            return ewhMapper.ToEwhWebsites(_websiteRepository.FindAll().OrderByDescending(x=>x.CreatedDate).ToList());
        }

        public List<EwhWebsite> GetListEwhWebsite(List<string> WebsiteIds)
        {
            return ewhMapper.ToEwhWebsites(_websiteRepository.FindAll().Where(x=>WebsiteIds.Contains(x.Id)).OrderByDescending(x => x.CreatedDate).ToList());
        }

        public void SyncWebsite(string id)
        {
            var website = GetEwhWebsite(id);
            if (website.IsExits())
            {
                website.SelfSync();
            }
        }

        public EwhWebsite InitEwhWebsite()
        {
            return new EwhWebsite(_websiteRepository, _accountRepository, _ewhMapper);
        }

        
    }
}
