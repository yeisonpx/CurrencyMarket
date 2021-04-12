using CurrencyMarket.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Configuration.Validations
{
    public class CreateExchangeRequestValidator : AbstractValidator<CreateExchangeRequest>
    {
        public CreateExchangeRequestValidator()
        {
            this.RuleFor(a => a.Amount).GreaterThan(0);
            this.RuleFor(a => a.UserId).NotEmpty().NotNull();
            this.RuleFor(a => a.CurrencyCode).NotNull().NotEmpty();
        }
    }
}
