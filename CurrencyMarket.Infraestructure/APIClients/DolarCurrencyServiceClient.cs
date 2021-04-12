using CurrencyMarket.Common.Settings;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.Proxies;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Infraestructure.APIClients
{
    public class DolarCurrencyServiceClient : ICurrencyMarketServiceClient
    {
        private IHttpClientFactory _ClientFactory;
        private AppSettings _AppSettings;

        public DolarCurrencyServiceClient(IHttpClientFactory clientFactory,
            IOptions<AppSettings> options
            )
        {
            _ClientFactory = clientFactory;
            _AppSettings = options.Value;
        }

        public async  Task<CurrencyPrice> GetCurrenPriceAsync()
        {
            var client = _ClientFactory.CreateClient("DolarHttpClient");
            var response = await client.GetAsync(_AppSettings.DolarWebApiUri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string[] args = JsonConvert.DeserializeObject<string[]>(content);
                double buyPrice = Convert.ToDouble(args[0]);
                double salePrice = Convert.ToDouble(args[1]);
                string message = args[2];
                return new CurrencyPrice
                {
                    BuyPrice = buyPrice,
                    SalePrice = salePrice,
                    Message = message
                };
            }

            throw new HttpRequestException("Service DolarHttpClient was unable to give a response for the request.");
        }
    }
}
