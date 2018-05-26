using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MedicalClinicApi
{
    public static class WebApiConfig
    {
        private static string GetAllowedOrigins()
        {
            //Make a call to the database to get allowed origins and convert to a comma separated string
            return "http://localhost:49715,http://localhost:4200";
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            string origins = GetAllowedOrigins();
            var cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);

            //config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetAPI",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "patients", action = "GetPatients", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetSingleAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "patients", action = "GetPatient", id = RouteParameter.Optional }
            );            

            config.Routes.MapHttpRoute(
                name: "UpdateAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "patients", action = "PutPatient", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
