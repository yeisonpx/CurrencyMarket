using CurrencyMarket.Infraestructure.Repositories;
using CurrencyMarket.WebApi.Configuration.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Configuration.Extensions
{
    public  static class DbContextConfigExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CurrencyMarketDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CurrencyMarketConnection"))
            );
            services.AddTransient<IStartupFilter, MigrationStartupFilter<CurrencyMarketDbContext>>();
            return services;
        }
    }
}
