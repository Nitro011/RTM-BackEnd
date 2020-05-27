using RTM.Models;
using RTM.Repository;
using RTM.Repository.Interface;
using RTM.Repository.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace RayTrackingMobile
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType< IGenericRepository<Almacen>,GenericRepository<Almacen>>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}