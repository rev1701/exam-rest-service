using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LMS1701.EA

{
    public static class WebApiConfig
    {
        public static string baseUrl = "http://localhost:51367/";
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                     name: "ActionApi",
                     routeTemplate: "api/{controller}/{action}/{id}",
                     defaults: new { id = RouteParameter.Optional }
                 );

            config.Routes.MapHttpRoute(
                      name: "DefaultApi",
                      routeTemplate: "api/{controller}/{id}",
                      defaults: new { id = RouteParameter.Optional }
                  );
        }
    }
}
