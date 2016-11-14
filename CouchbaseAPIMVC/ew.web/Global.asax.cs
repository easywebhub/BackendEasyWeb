using Couchbase;
using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ew.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = new ClientConfiguration();
            config.Servers = new List<Uri>
        {
            new Uri(ConfigurationManager.AppSettings["couchbaseServer1"])
        };
            config.UseSsl = false;
            ClusterHelper.Initialize(config);
        }


        protected void Application_End()
        {
            ClusterHelper.Close();
        }
    }
}
