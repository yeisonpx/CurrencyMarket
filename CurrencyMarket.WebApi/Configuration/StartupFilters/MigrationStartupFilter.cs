using CurrencyMarket.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Configuration.StartupFilters
{
    public class MigrationStartupFilter<TContext> : IStartupFilter where TContext : DbContext
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    foreach (var context in scope.ServiceProvider.GetServices<TContext>())
                    {
                        context.Database.SetCommandTimeout(160);
                        context.Database.Migrate();                        
                    }
                }
                next(app);
            };
        }
    }
}
