using System.Collections.Generic;
using ew.application.Entities;

namespace ew.application.Services
{
    public interface IAccountService
    {
        EwhAccount GetByUserName(string username);
        bool IsExitsUserName(string username);
        List<EwhAccount> GetListAccount(List<string> listAccountId);
        string Save(EwhAccount account);
    }
}