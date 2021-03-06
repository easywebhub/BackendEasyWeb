﻿using ew.application.Entities;
using ew.application.Entities.Dto;
using ew.common.Entities;
using ew.core.Dtos;
using System.Collections.Generic;

namespace ew.application
{
    public interface IAccountManager: IEwhEntityBase
    {
        EwhAccount EwhAccountAdded { get; }

        bool CreateAccount(AddAccountDto dto);
        bool CreateAccount(EwhAccount account);
        bool UpdateAccount(EwhAccount account);
        EwhAccount GetEwhAccount(string id);
        List<EwhAccount> GetListAccount(AccountQueryParams queryParams = null);
        EwhAccount InitEwhAccount();
    }
}