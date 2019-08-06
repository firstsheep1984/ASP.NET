using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstRouteApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Users", url: "Users/{username}",
                defaults: new
                {
                    controller = "Users",
                    action = "ByUserName",
                    username = UrlParameter.Optional
                });

            routes.MapRoute(name: "Blog", url: "{year}/{month}/{day}",
                defaults: new
                {
                    controller = "Blog",
                    action = "ByDate"
                },
                    constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
