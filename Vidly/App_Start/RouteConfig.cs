using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();


            //Define from most specific to more generic , as the orders of the route matter;

            //Custom Routes
            //routes.MapRoute(
            //        "MoviesByReleaseDate",
            //        "movies/released/{year}/{month}",
            //        new { controller = "Movies", action= "ByReleaseDate" },
            //        new {year=@"2015|2016", month = @"\d{2}"}
            //        );

            //Default Route config ; "Action = action define in controller"
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
