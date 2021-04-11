using CurrencyMarket.Core.Interfaces.Repositories;
using CurrencyMarket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Infraestructure.Repositories
{
    public class CurrencyMarketDbContext : DbContext
    {
        private readonly IDataBaseInitiation _BaseInitiation;
        public CurrencyMarketDbContext(DbContextOptions<CurrencyMarketDbContext> options,
            IDataBaseInitiation dataBaseInitiation
            ):base(options) {
            _BaseInitiation = dataBaseInitiation;
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddDefaultData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void AddDefaultData(ModelBuilder modelBuilder)
        {
            var config = _BaseInitiation.GetDataConfig();
            if (config != null)
            {
                modelBuilder.Entity<Currency>().HasData(config.DefaultCurrencies);
            }
        }
    }
}
