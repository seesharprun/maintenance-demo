using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Maintenance.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "Index" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "Primary",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
