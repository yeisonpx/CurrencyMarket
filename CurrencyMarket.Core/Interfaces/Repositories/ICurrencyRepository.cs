using CurrencyMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Currency Get(string code);
        double GetExchangeMonthSummary(int userId, string currencyId);
    }
}
