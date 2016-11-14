using System.Collections.Generic;
using ew.application.Entities;

namespace ew.application.Services
{
    public interface IWebsiteService
    {
        EwhWebsite Get(string id);
        List<EwhWebsite> GetListWebsite(List<string> listWebsiteId);
    }
}