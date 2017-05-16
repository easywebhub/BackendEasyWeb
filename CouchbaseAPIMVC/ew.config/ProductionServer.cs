using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.config
{
    public class ProductionServer
    {
        public static string BaseUrl = "https://production.easywebhub.com/";
        public static string WebHookUrl = string.Format("{0}web-hook/", BaseUrl);
        public static string SecretKey = "bay gio da biet";
    }
}
