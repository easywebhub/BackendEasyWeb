using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CouchbaseAPIMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Orders",
                routeTemplate: "api-order/{action}/{id}",
                defaults: new { controller = "Orders", action = "GetListCustomers", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
              name: "User",
              routeTemplate: "api-user/{action}/{id}",
              defaults: new { controller = "User", action = "GetListCustomers", id = RouteParameter.Optional }
          );
        }
    }
}
