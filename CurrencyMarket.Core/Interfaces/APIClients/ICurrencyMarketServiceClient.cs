using CurrencyMarket.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.Interfaces.Proxies
{
    public interface ICurrencyMarketServiceClient
    {
        Task<CurrencyPrice> GetCurrenPriceAsync();
    }
}
