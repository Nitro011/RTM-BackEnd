using Microsoft.Extensions.DependencyInjection;
using RTM.Repository;
using RTM.Repository.Interface;
using RTM.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTM.Application.Midleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependecy(this IServiceCollection service) 
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return service;
        }


    }
}
