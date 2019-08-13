using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Comments",
                url: "Comments/Index/{postId}",
                defaults: new { controller = "Comments", action = "Index", postId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CommentsEdit",
                url: "Comments/Edit/{id}/{postId}",
                defaults: new { controller = "Comments", action = "Edit", id = UrlParameter.Optional, postId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CommentsDelete",
                url: "Comments/Delete/{id}/{postId}",
                defaults: new { controller = "Comments", action = "Delete", id = UrlParameter.Optional, postId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
