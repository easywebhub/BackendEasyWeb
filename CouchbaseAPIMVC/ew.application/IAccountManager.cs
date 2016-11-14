using ew.application.Entities;
using System.Collections.Generic;

namespace ew.application
{
    public interface IAccountManager: IEwhEntityBase
    {
        EwhAccount EwhAccountAdded { get; }

        bool CreateAccount();
        List<EwhAccount> GetListAccount();
    }
}