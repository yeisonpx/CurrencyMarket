using CurrencyMarket.Common;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.Proxies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Infraestructure.APIClients
{
    public class RealCurrencyServiceClient : ICurrencyMarketServiceClient
    {
        private readonly ICurrencyMarketServiceClientFactory _Factory;

        public RealCurrencyServiceClient(ICurrencyMarketServiceClientFactory factory)
        {
            _Factory = factory;
        }
        public async Task<CurrencyPrice> GetCurrenPriceAsync()
        {
            var dolarProxy = _Factory.Get(CurrenciesShortCodes.DOLAR);
            var price = await dolarProxy.GetCurrenPriceAsync();
            return new CurrencyPrice
            {
                BuyPrice = price.BuyPrice / 4,
                SalePrice = price.SalePrice / 4,
                Message = price.Message
            };
        }
    }
}
