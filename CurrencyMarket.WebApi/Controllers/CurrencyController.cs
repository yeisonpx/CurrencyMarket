using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using CurrencyMarket.WebApi.Configuration.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyMarket.WebApi.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {        
        private ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest(ErrorMessages.INVALID_CURRENCY_CODE);
            }
            var price = await _currencyService.GetCurrencyPriceAsync(code);            
            return Ok(price);
        }
    }
}
