using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Entities
{
    public class CurrencyExchange
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public long Amount { get; set; }
        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
