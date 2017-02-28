using ew.core.Dtos;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Repositories
{
    public interface IAccountRepository: IGenericRepository<Account>
    {
        IQueryable<Account> Find(EntityQueryParams queryParams);
        bool IsExitsUserName(string username);
        Account GetByUsername(string username);
        bool IsExitsEmail(string email);
        bool IsIdentityEmail(string username, string email);
        bool AddWebsite(AddWebsiteAccountModel dto);
        bool RemoveWebsite(RemoveWebsiteAccountModel dto);
    }
}
