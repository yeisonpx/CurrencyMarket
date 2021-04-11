using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMarket.Common.Exceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException() :base("Invalid currency."){}
    }
}
