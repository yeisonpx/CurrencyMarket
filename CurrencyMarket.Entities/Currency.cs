using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Entities
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double ExchangeLimit { get; set; }
    }
}
