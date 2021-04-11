using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Common.Exceptions
{
    public class CurrencyExchangeLimitException : Exception
    {
        public CurrencyExchangeLimitException(double limit, string currencyName) 
            : base($"User exceeded the current limit of {limit} {currencyName} currency exchange per month.")
        {

        }
    }
}
