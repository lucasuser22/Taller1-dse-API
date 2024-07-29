using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.BL.Automapper;
using Inventario.BL.Interfaces;
using Inventario.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventario.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddTransient<IProductoService, ProductoService>();
            services.AddRepositoryConnector();
            return services;
        }
    }
}
