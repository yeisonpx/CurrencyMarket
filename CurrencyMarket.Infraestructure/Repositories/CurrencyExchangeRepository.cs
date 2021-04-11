using CurrencyMarket.Core.Interfaces.Repositories;
using CurrencyMarket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Infraestructure.Repositories
{
    public class CurrencyExchangeRepository : ICurrencyExchangeRepository
    {
        private CurrencyMarketDbContext _DbContext;

        public CurrencyExchangeRepository(CurrencyMarketDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<CurrencyExchange> CreateAsync(CurrencyExchange request)
        {
            var created = await _DbContext.CurrencyExchanges.AddAsync(request);
            await _DbContext.SaveChangesAsync();
            return request;
        }

        public async Task<IEnumerable<CurrencyExchange>> GetAsync()
        {
            return await _DbContext.CurrencyExchanges.ToListAsync();
        }

    }
}
