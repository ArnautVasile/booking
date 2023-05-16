using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Booking.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute(
            //     name: "DeleteBarbershop",
            //     url: "Barbershop/DeleteBarbershop/{id}",
            //     defaults: new { controller = "Barbershop", action = "DeleteBarbershop", id = UrlParameter.Optional }
            // );

            routes.MapRoute(
               name: "AdminLogin",
               url: "Admin/Login/",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "AdminBarbershop",
                url: "Admin/Barbershop/{id}",
                defaults: new { controller = "Barbershop", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AdminEmployee",
               url: "Admin/Employee/{id}",
               defaults: new { controller = "EmployeeBarbershop", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "AdminService",
               url: "Admin/Service/{id}",
               defaults: new { controller = "ServiceBarbEmp", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Booking",
               url: "booking/{id}",
               defaults: new { controller = "Booking", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

         //   routes.MapRoute(
         //       name: "AddBarbershop",
         //       url: "Admin/AddBarbershop/",
          //      defaults: new { controller = "Barbershop", action = "Index", id = UrlParameter.Optional }
          //  );

            //     routes.MapRoute(
            //         name: "CatchAll",
            //         url: "{*url}",
            //        defaults: new { controller = "Barbershop", action = "Index", id = UrlParameter.Optional }
            //    );
        }
    }
}
