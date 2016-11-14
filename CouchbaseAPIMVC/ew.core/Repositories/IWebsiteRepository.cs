using ew.core.Dto;
using ew.core.Dtos;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Repositories
{
    public interface IWebsiteRepository: IGenericRepository<Website>
    {
        bool AddAccount(AddWebsiteAccountModel dto);
        bool RemoveAccount(RemoveWebsiteAccountModel dto);
        bool AddOrUpdateStaging(DeploymentEnviromentModel dto);
        bool RemoveStaging(DeploymentEnviromentModel dto);
        bool AddOrUpdateProduction(DeploymentEnviromentModel dto);
        bool RemoveProduction(DeploymentEnviromentModel dto);
    }
}
