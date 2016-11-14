using ew.application.Entities;
using System.Collections.Generic;

namespace ew.application
{
    public interface IWebsiteManager: IEwhEntityBase
    {
        EwhWebsite EwhWebsiteAdded { get; }

        bool CreateWebsite();
        EwhWebsite GetEwhWebsite(string id);
        List<EwhWebsite> GetListEwhWebsite();
    }
}