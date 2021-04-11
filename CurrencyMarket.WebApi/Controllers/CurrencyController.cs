using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyMarket.Core.Interfaces.BusinessServices;
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
                return BadRequest("Currenncy code can not be empty.");
            }
            var price = await _currencyService.GetCurrencyPriceAsync(code);            
            return Ok(price);
        }
    }
}
