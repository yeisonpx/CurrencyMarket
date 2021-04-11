using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Core.DTOs
{
    public class CreateExchangeRequest
    {
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
