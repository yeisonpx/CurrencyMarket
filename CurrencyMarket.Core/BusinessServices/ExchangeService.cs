using CurrencyMarket.Common.Exceptions;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using CurrencyMarket.Core.Interfaces.Proxies;
using CurrencyMarket.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.BusinessServices
{
    public class ExchangeService : IExchangeService
    {
        private readonly ICurrencyService _CurrencyService;
        private ICurrencyRepository _CurrencyRepository;
        private ICurrencyExchangeRepository _ExchangeRepository;

        public ExchangeService(
             ICurrencyService currencyService,
             ICurrencyRepository currencyRepository,
             ICurrencyExchangeRepository exchangeRepository
             )
        {
            _CurrencyService = currencyService;
            _CurrencyRepository = currencyRepository;
            _ExchangeRepository = exchangeRepository;
        }

        public async Task<CreateExchangeResponse> CreateAsync(CreateExchangeRequest request)
        {
            var currency = _CurrencyRepository.Get(request.CurrencyCode);
            if(currency == null)
            {
                throw new InvalidCurrencyException();
            }
            
            var currencyPrice = await _CurrencyService.GetCurrencyPriceAsync(request.CurrencyCode);
            double requestAmount = Math.Round(request.Amount / currencyPrice.SalePrice, 2);
            double currentMonthExchanges = _CurrencyRepository.GetExchangeMonthSummary(request.UserId, currency.Id);
            double total = requestAmount + currentMonthExchanges;
            if (total > currency.ExchangeLimit)
            {
                throw new CurrencyExchangeLimitException(currency.ExchangeLimit, currency.Name);
            }           

            var exchange = new Entities.CurrencyExchange()
            {
                Amount = requestAmount,
                CurrencyId = currency.Id,
                UserId = request.UserId,
                CreationDate = DateTime.Now,                
            };

            var created = await _ExchangeRepository.CreateAsync(exchange);
            return new CreateExchangeResponse()
            {
                Id = created.Id,
                Amount = created.Amount,
                CurrencyId = created.Currency.Id,
                CurrencyName = created.Currency.Name,
                UserId = request.UserId
            };
        }
    }
}
