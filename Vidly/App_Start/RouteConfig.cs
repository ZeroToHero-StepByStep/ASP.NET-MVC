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

            //when define the route , the schedule is very important , from the very specific to the generic 
            //the third argument here is to set the default 
            //the fourth argument here is to set the constraint
            routes.MapRoute("MoviesByReleaseDate","movies/released/{year}/{month}" , new {controller="Movies" , action="ByReleaseDate"} , new {/*year=@"\d{4}" ,*/ year=@"2015|2016", month=@"\d{2}"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
