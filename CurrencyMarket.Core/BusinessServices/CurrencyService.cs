using CurrencyMarket.Common.Exceptions;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using CurrencyMarket.Core.Interfaces.Proxies;
using CurrencyMarket.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.BusinessServices
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyMarketServiceClientFactory _ProxyFactory;

        public CurrencyService(
            ICurrencyMarketServiceClientFactory currencyProxyFactory
            )
        {
            _ProxyFactory = currencyProxyFactory;
        }

        public async Task<CurrencyPrice> GetCurrencyPriceAsync(string code)
        {
            var proxy =_ProxyFactory.Get(code);
            return await proxy.GetCurrenPriceAsync();            
        }
    }
}
