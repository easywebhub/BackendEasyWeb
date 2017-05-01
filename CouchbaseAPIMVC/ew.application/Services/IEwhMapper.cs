using System.Collections.Generic;
using ew.application.Entities;
using ew.core;
using ew.core.Users;
using ew.application.Entities.Dto;
using ew.core.Dtos;
using ew.core.Dto;

namespace ew.application.Services
{
    public interface IEwhMapper
    {
        //EwhAccount ToEwhAccount(Account account);
        List<EwhAccount> ToEwhAccounts(List<Account> listAccount);
        List<EwhWebsite> ToEwhWebsites(List<Website> listWebsite);
        EwhAccount ToEntity(EwhAccount ewhAccount, Account account);
        EwhAccount ToEntity(EwhAccount ewhAccount, AddAccountDto account);
        Account ToEntity(Account account, EwhAccount ewhAccount);
        AddAccountDto ToEntity(AddAccountDto dto, EwhAccount ewhAccount);

        Website ToEntity(Website website, EwhWebsite ewhWebsite);
        WebsiteIdentity ToEntity(WebsiteIdentity entity, AddWebsiteAccountDto dto);
        EwhWebsite ToEntity(EwhWebsite ewhWebsite, CreateWebsiteDto dto);
        AccountsAccessLevelOfWebsite ToEntity(AccountsAccessLevelOfWebsite entity, AddWebsiteAccountDto dto);
        DeploymentEnviromentModel ToEntity(DeploymentEnviromentModel model, UpdateDeploymentEnvironmentToWebsite dto);
    }
}