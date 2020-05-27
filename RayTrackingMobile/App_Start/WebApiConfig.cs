using RayTrackingMobile.Dependency;
using RTM.Models;
using RTM.Repository;
using RTM.Repository.Interface;
using RTM.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace RayTrackingMobile
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IGenericRepository<Almacen>, GenericRepository<Almacen>>();
            config.DependencyResolver = new UnityResolver(container);
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
