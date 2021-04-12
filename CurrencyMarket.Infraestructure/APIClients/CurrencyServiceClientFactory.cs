using CurrencyMarket.Common;
using CurrencyMarket.Common.Exceptions;
using CurrencyMarket.Common.Settings;
using CurrencyMarket.Core.Interfaces.Proxies;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace CurrencyMarket.Infraestructure.APIClients
{
    public class CurrencyServiceClientFactory : ICurrencyMarketServiceClientFactory
    {
        private IHttpClientFactory _httpClientFactory;
        private IOptions<AppSettings> _appSettings;

        public CurrencyServiceClientFactory(IHttpClientFactory factory,
            IOptions<AppSettings> options
            )
        {
            _httpClientFactory = factory;
            _appSettings = options;
        }
        public ICurrencyMarketServiceClient Get(string code)
        {
            switch (code)
            {
                case CurrenciesShortCodes.DOLAR:
                    return new DolarCurrencyServiceClient(_httpClientFactory, _appSettings);
                case CurrenciesShortCodes.REAL:
                    return new RealCurrencyServiceClient(this);
                default:
                    throw new InvalidCurrencyException();                    
            }
        }
    }
}
