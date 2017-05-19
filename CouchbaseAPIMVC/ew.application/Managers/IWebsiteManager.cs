using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ew.application
{
    public interface IWebsiteManager: IEwhEntityBase
    {
        EwhWebsite EwhWebsiteAdded { get; }
        EwhWebsite InitEwhWebsite();
        bool CreateWebsite(CreateWebsiteDto dto);
        bool CreateWebsite(EwhWebsite dto);
        bool ConfirmWebsite(string websiteId) //bao
        bool UpdateWebsite(EwhWebsite website);
        EwhWebsite GetEwhWebsite(string id);
        List<EwhWebsite> GetListEwhWebsite();
        List<EwhWebsite> GetListEwhWebsite(List<string> WebsiteIds);
        
    }
}