using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Core.Interfaces.Proxies
{
    public interface ICurrencyMarketProxyFactory
    {
        ICurrencyMarketProxy Get(string code);
    }
}
