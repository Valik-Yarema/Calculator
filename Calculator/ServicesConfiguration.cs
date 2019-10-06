using BAL.Managers;
using DAL.Repositories;
using Interface.InterfacesBAL;
using Interface.InterfacesDAL;
using Microsoft.Extensions.DependencyInjection;
using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddAllScoped(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #region Manager
            services.AddScoped<IComputingManager, ComputingManager>();
            #endregion

            return services;
        }
        public static IServiceCollection AddAllTransient(this IServiceCollection services)
        {
            #region Repository
            services.AddTransient<IBaseRepository<Computing>, BaseRepository<Computing>>();
            #endregion

           
            return services;
        }
    }
}
