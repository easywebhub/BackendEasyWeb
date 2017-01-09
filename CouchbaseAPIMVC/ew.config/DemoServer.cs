using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.config
{
    public class DemoServer
    {
        public static string BaseUrl = "https://demo.easywebhub.com/";
        public static string WebHookUrl = string.Format("{0}web-hook/", BaseUrl);
    }
}
