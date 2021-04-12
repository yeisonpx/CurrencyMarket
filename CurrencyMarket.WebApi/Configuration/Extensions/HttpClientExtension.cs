using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Configuration.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddHttpClient("DolarHttpClient", options =>
            {
                options.BaseAddress = new Uri(configuration["AppSettings:DolarWebApiUri"]);
            });
            return services;
        }
    }
}
