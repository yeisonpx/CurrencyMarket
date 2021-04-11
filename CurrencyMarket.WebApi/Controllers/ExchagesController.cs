using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Controllers
{
    [ApiController]
    [Route("api/exchanges")]
    public class ExchagesController : ControllerBase
    {
        private readonly IExchangeService _ExchangeService;

        public ExchagesController(IExchangeService exchangeService)
        {
            _ExchangeService = exchangeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateExchangeRequest request)
        {
            var response = await _ExchangeService.CreateAsync(request);
            return CreatedAtAction(nameof(Post),response);
        }
    }
}
