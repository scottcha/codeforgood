using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeForGood.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(null,
                            "",
                            new
                            {
                                controller = "Project",
                                action = "List",
                                category = (string)null,
                                page = 1
                            });

            routes.MapRoute(null,
                            "Page{page}",
                            new { controller = "Project", action = "List", category = (string)null },
                            new { page = @"\d+" });

            routes.MapRoute(null,
                            "{category}",
                            new { controller = "Project", action = "List", page = 1 });

            routes.MapRoute(null,
                            "{category}/Page{page}",
                            new { controller = "Project", action = "List" },
                            new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");

            /* default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
             * */
        }
    }
}
