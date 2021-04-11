using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyMarket.Common.Settings;
using CurrencyMarket.Core.BusinessServices;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using CurrencyMarket.Core.Interfaces.Proxies;
using CurrencyMarket.Core.Interfaces.Repositories;
using CurrencyMarket.Core.Proxies;
using CurrencyMarket.Infraestructure.Repositories;
using CurrencyMarket.WebApi.Configuration.Middlewares;
using CurrencyMarket.WebApi.Configuration.StartupFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CurrencyMarket.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();            
            services.AddScoped<IDataBaseInitiation, DataBaseInitiation>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IExchangeService, ExchangeService>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyExchangeRepository, CurrencyExchangeRepository>();
            services.AddScoped<ICurrencyMarketProxyFactory, CurrencyMarkeProxyFactory>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<CurrencyMarketDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("CurrencyMarketConnection"))
            );
            services.AddTransient<IStartupFilter, MigrationStartupFilter<CurrencyMarketDbContext>>();
            services.AddHttpClient("DolarHttpClient", options =>
            {
                options.BaseAddress = new Uri(Configuration["AppSettings:DolarWebApiUri"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorEventMiddleware>();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
