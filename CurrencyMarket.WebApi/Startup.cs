using CurrencyMarket.Common.Settings;
using CurrencyMarket.Core.BusinessServices;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using CurrencyMarket.Core.Interfaces.Proxies;
using CurrencyMarket.Core.Interfaces.Repositories;
using CurrencyMarket.Infraestructure.APIClients;
using CurrencyMarket.Infraestructure.Repositories;
using CurrencyMarket.WebApi.Configuration.Extensions;
using CurrencyMarket.WebApi.Configuration.Middlewares;
using CurrencyMarket.WebApi.Configuration.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddControllers().AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateExchangeRequestValidator>());            
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IExchangeService, ExchangeService>();

            services.AddScoped<IDataBaseInitiation, DataBaseInitiation>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyExchangeRepository, CurrencyExchangeRepository>();
            services.AddScoped<ICurrencyMarketServiceClientFactory, CurrencyServiceClientFactory>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContextConfig(Configuration);
            services.AddHttpClients(Configuration);
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

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
