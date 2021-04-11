using CurrencyMarket.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMarket.Core.Interfaces.BusinessServices
{
    public interface IExchangeService
    {
        Task<CreateExchangeResponse> CreateAsync(CreateExchangeRequest request);
    }
}
