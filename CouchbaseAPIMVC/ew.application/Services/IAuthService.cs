using ew.application.Entities;

namespace ew.application.Services
{
    public interface IAuthService
    {
        bool CheckUserAuth(string username, string password);
        EwhAccount AuthorizedAccount();
    }
}