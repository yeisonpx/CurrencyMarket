using CurrencyMarket.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.Interfaces.BusinessServices
{
    public interface ICurrencyService
    {
        Task<CurrencyPrice> GetCurrencyPriceAsync(string code);
    }
}
