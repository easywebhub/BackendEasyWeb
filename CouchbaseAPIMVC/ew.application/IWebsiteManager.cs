using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.common.Entities;
using System.Collections.Generic;

namespace ew.application
{
    public interface IWebsiteManager: IEwhEntityBase
    {
        EwhWebsite EwhWebsiteAdded { get; }

        bool CreateWebsite(CreateWebsiteDto dto);
        EwhWebsite GetEwhWebsite(string id);
        List<EwhWebsite> GetListEwhWebsite();
    }
}