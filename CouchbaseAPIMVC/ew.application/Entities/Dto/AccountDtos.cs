using ew.core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities.Dto
{
    public class AddAccountDto
    {
        [Required]
        public string AccountType { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public AccountInfo Info { get; set; }

        public AddAccountDto() { }
    }

    public class AddWebsiteAccountDto
    {
        public string WebsiteId { get; set; }
        public string AccountId { get; set; }
        public List<string> AccessLevels { get; set; }
        public string WebsiteDisplayName { get; set; }
    }

}
