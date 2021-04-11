using CurrencyMarket.Entities;

namespace CurrencyMarket.Core.Interfaces.Repositories
{
    public interface IDataBaseInitiation
    {
        DefaultDataConfig GetDataConfig();
    }
}