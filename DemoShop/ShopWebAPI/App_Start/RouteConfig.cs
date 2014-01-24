using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //  routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //    routes.MapHttpRoute(
            //    name: "ApiById",
            //    routeTemplate: "{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
            //    constraints: new { id = @"^[0-9]+$" }
            //);

            //    routes.MapHttpRoute(
            //        name: "ApiByName",
            //        routeTemplate: "{controller}/{action}/{name}",
            //        defaults: null,
            //        constraints: new { name = @"^[a-z]+$" }
            //    );

            //    routes.MapHttpRoute(
            //        name: "ApiByAction",
            //        routeTemplate: "{controller}/{action}",
            //        defaults: new { action = "Get" }
            //    );
            //}
        }
    }
}