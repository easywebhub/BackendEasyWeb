using ew.core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Dtos
{

    public class AddWebsiteAccountModel
    {
        public Website Website { get; set; }
        public Account Account { get; set; }
        public List<string> AccessLevels { get; set; }
        public string WebsiteDisplayName { get; set; }
    }

    public class RemoveWebsiteAccountModel
    {
        public Website Website { get; set; }
        public Account Account { get; set; }
    }
}
