using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Models
{
    public class RequestErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
