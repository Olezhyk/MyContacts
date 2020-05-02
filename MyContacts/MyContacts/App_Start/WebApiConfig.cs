using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using MyContacts.BusinessLogic.InversionOfControl;
using MyContacts.BusinessLogic.Log;
using MyContacts.BusinessLogic.Services.ServiceImplementation;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.DataAccess.Implementation;
using MyContacts.DataAccess.Interfaces;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Injection;
using Unity.Lifetime;

namespace MyContacts
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
