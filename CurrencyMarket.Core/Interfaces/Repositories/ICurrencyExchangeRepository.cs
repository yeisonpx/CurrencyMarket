using CurrencyMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.Interfaces.Repositories
{
    public interface ICurrencyExchangeRepository
    {
        public Task<IEnumerable<CurrencyExchange>> GetAsync();
        Task<CurrencyExchange> CreateAsync(CurrencyExchange request);
    }
}
