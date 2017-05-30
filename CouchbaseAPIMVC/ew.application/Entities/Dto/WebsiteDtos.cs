using ew.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities.Dto
{
    public class UserCreateWebsiteDto
    {
        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        //public List<AddWebsiteAccountDto> Accounts { get; set; }
        public string WebTemplateId { get; set; }

        public UserCreateWebsiteDto() { }
        public UserCreateWebsiteDto(UserCreateWebsiteDto dto)
        {
            this.Name = dto.Name;
            this.DisplayName = dto.DisplayName;
            this.Url = dto.Url;
            this.WebTemplateId = dto.WebTemplateId;
        }
    }

    public class CreateWebsiteDto : UserCreateWebsiteDto
    {
        //public string Name { get; set; }
        //public string DisplayName { get; set; }
        //public string Url { get; set; }
        public List<AddWebsiteAccountDto> Accounts { get; set; }
        //public string WebTemplateId { get; set; }
        public bool EnableAutoConfirm { get; set; }

        public CreateWebsiteDto() : base() {
            EnableAutoConfirm = false;
        }
        public CreateWebsiteDto(string userId, UserCreateWebsiteDto dto) : base(dto)
        {
            this.Accounts = new List<AddWebsiteAccountDto>() {
                new AddWebsiteAccountDto() {
                    AccessLevels = new List<string>() { AccessLevels.Owner.ToString() }, AccountId = userId }
            };
        }
    }

    public class UpdateDeploymentEnvironmentToWebsite
    {
        //public string WebsiteId { get; set; } // Add/Update/Remove
        public string EnviromentId { get; set; }
        public string Name { get; set; }
        public string HostingFee { get; set; }
        public string Url { get; set; }
        public string Git { get; set; }
        public bool IsDefault { get; set; }
    }

    public class UpdateAccountAccessLevelToWebsite
    {
        //public string WebsiteId { get; set; }
        public string AccountId { get; set; }
        public List<string> AccessLevels { get; set; }
        //public string WebsiteDisplayName { get; set; }

        public UpdateAccountAccessLevelToWebsite()
        {
            AccessLevels = new List<string>();
        }
    }


}
