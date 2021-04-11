using CurrencyMarket.Common;
using CurrencyMarket.Common.Exceptions;
using CurrencyMarket.Common.Settings;
using CurrencyMarket.Core.Interfaces.Proxies;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CurrencyMarket.Core.Proxies
{
    public class CurrencyMarkeProxyFactory : ICurrencyMarketProxyFactory
    {
        private IHttpClientFactory _httpClientFactory;
        private IOptions<AppSettings> _appSettings;

        public CurrencyMarkeProxyFactory(IHttpClientFactory factory,
            IOptions<AppSettings> options
            )
        {
            _httpClientFactory = factory;
            _appSettings = options;
        }
        public ICurrencyMarketProxy Get(string code)
        {
            switch (code)
            {
                case CurrenciesShortCodes.DOLAR:
                    return new DolarCurrencyProxy(_httpClientFactory, _appSettings);
                case CurrenciesShortCodes.REAL:
                    return new RealCurrencyProxy(this);
                default:
                    throw new InvalidCurrencyException();                    
            }
        }
    }
}
