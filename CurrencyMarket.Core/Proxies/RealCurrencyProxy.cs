using CurrencyMarket.Common;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.Proxies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.Proxies
{
    public class RealCurrencyProxy : ICurrencyMarketProxy
    {
        private readonly ICurrencyMarketProxyFactory _Factory;

        public RealCurrencyProxy(ICurrencyMarketProxyFactory factory)
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
