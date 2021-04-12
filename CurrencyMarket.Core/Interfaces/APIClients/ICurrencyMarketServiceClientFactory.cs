using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Core.Interfaces.Proxies
{
    public interface ICurrencyMarketServiceClientFactory
    {
        ICurrencyMarketServiceClient Get(string code);
    }
}
