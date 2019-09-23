using BakeryShop.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop
{
    public sealed class ConfigureDependency
    {
        private ConfigureDependency()
        {

        }
        public static void  Configure(IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
        }
    }
}
