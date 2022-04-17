using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlyCart.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
               name: "Home",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Product",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Catagory",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Catagory", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );

        }
    }
}
