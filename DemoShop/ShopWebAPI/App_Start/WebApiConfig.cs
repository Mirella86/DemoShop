using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplicationService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //    config.Routes.MapHttpRoute(
            //        name: "DefaultApi",
            //        routeTemplate: "api/{controller}/{id}",
            //        defaults: new { id = RouteParameter.Optional, action = "Get" }
            //    );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
 name: "ApiById",
 routeTemplate: "{controller}/{id}",
 defaults: new { id = RouteParameter.Optional },
 constraints: new { id = @"^[0-9]+$" }
);

            config.Routes.MapHttpRoute(
                name: "ApiByName",
                routeTemplate: "{controller}/{action}/{name}",
                defaults: null,
                constraints: new { name = @"^[a-z]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "{controller}/{action}",
                defaults: new { action = "Get" }
            );

            config.Routes.MapHttpRoute(
              name: "ApiByActionId",
              routeTemplate: "{controller}/{action}/{id}",
              defaults: new { action = "Get" }
          );
        }


        // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
        // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
        // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
        //config.EnableQuerySupport();

        // To disable tracing in your application, please comment out or remove the following line of code
        // For more information, refer to: http://www.asp.net/web-api
        //  config.EnableSystemDiagnosticsTracing();

    }
}
