using ew.application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities
{
    public class EwhMail
    {
        private readonly MailService _mailService;

        public EwhMail()
        {

        }

        public bool Compose()
        {
            return false;
        }
    }
}
