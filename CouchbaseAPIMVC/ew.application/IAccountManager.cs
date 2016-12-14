using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.core.Dtos;
using System.Collections.Generic;

namespace ew.application
{
    public interface IAccountManager: IEwhEntityBase
    {
        EwhAccount EwhAccountAdded { get; }

        bool CreateAccount(AddAccountDto dto);
        EwhAccount GetEwhAccount(string id);
        List<EwhAccount> GetListAccount(AccountQueryParams queryParams = null);
    }
}