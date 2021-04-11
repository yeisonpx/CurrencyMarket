using CurrencyMarket.Core.Interfaces.Repositories;
using CurrencyMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Infraestructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private CurrencyMarketDbContext _DbContext;

        public CurrencyRepository(CurrencyMarketDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Currency Get(string id)
        {
            var currency =  _DbContext.Currencies.FirstOrDefault(a=>a.Id == id);
            return currency;
        }

        public double GetExchangeMonthSummary(int userId, string currencyId)
        {
            return _DbContext.CurrencyExchanges
                .Where(a =>a.UserId == userId 
                && a.CreationDate.Month == DateTime.Now.Month
                && a.CurrencyId == currencyId)
                .Sum(a => a.Amount);
        }
    }
}
