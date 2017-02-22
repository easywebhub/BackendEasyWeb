using Couchbase;
using Couchbase.Configuration.Client;
using ew.common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ew.webapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
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

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            //log error
            LogException(exception);
        }

        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;

            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
                return;

            try
            {
                //log
                EwhLogger.Common.Error(exc.Message, exc);
            }
            catch (Exception ex)
            {
                //don't throw new exception if occurs
                throw ex;
            }
        }

    }
}
