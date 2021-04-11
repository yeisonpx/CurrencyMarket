using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Core.DTOs
{
    public class CreateExchangeResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string CurrencyId { get; set; }
        public string CurrencyName { get; set; }
    }
}
