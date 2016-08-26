using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Couchbase;
using Couchbase.Configuration.Client;
using CouchbaseAPIMVC.App_Start;

namespace CouchbaseAPIMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           CouchbaseConfig.Initialize();
           /* var config = new ClientConfiguration
            {
                Servers = new List<Uri>
                {
                    //change this to your cluster to bootstrap
                   // new Uri("http://45.117.80.57/:8091/"),

                    new Uri("http://localhost/:8091/")
                    }
            };

            ClusterHelper.Initialize(config); */
        }
    }
}
