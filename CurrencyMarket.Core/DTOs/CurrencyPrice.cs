using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Core.DTOs
{
    public class CurrencyPrice
    {
        public double BuyPrice { get; set; }
        public double SalePrice { get; set; }
        public string Message { get; set; }
    }
}
