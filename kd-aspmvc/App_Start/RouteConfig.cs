using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace kd_aspmvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route override to work with Angularjs and HTML5 routing
            //routes.MapRoute(
            //    name: "AdminOverride",
            //    url: "Admin/{*.}",
            //    defaults: new { controller = "Admin", action = "Index" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        //public static void ConfigUserRoutes(RouteCollection routes)
        //{
        //    // Without this, Action helper in navigation menu creates current page's url instead of /users.
        //    routes.MapRoute(
        //        name: "UsersRoot",
        //        url: "index",
        //        defaults: new { controller = "Admin", action = "Index" });

        //    routes.MapRoute(
        //        name: "material",
        //        url: "admin/{*catchall}",
        //        defaults: new { controller = "Admin", action = "Material" });
        //}
    }
}
