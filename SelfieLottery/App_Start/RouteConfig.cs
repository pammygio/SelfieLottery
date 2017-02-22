using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SelfieLottery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
               name: "ResetDayLottery",
               url: "ResetDayLottery",
               defaults: new { controller = "Home", action = "ResetDayLottery", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Registrazione",
              url: "registrazione",
              defaults: new { controller = "Home", action = "Registrazione", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "Estrazione",
               url: "estrazione",
               defaults: new { controller = "Home", action = "Estrazione"}
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
