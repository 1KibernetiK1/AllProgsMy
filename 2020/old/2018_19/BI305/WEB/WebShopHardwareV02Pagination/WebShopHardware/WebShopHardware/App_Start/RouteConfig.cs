using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebShopHardware
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: 
                new
                {
                    controller = "Main",
                    action = "Products",
                    page = 1
                }
            );

            routes.MapRoute(
                null,
                "Page{page}",
                new
                {
                    controller = "Main",
                    action = "Products"
                },
                new {page = @"\d+"}
            );
        }
    }
}
