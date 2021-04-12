using CurrencyMarket.Core.BusinessServices;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.BusinessServices;
using CurrencyMarket.Core.Interfaces.Proxies;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CurrencyMarket.CoreTests
{
    public class CurrencyServiceTests
    {
        [Fact]
        public async Task get_USD_current_price_ShouldCallDolarHttpClient()
        {
            //Arrange
            string currencyCode = "dolar";
            var dolarPoxy = new Mock<ICurrencyMarketServiceClient>();
            var expected = new CurrencyPrice()
            {
                BuyPrice = 58,
                Message = "Test of message",
                SalePrice = 60
            };
            dolarPoxy.Setup(a => a.GetCurrenPriceAsync()).Returns(()=>Task.FromResult(expected));
            var proxyFactory = new Mock<ICurrencyMarketServiceClientFactory>();
            proxyFactory.Setup(a => a.Get(It.IsAny<string>())).Returns(dolarPoxy.Object);
            ICurrencyService currencyService = new CurrencyService(proxyFactory.Object);

            //Action
            CurrencyPrice currencyPrice = await currencyService.GetCurrencyPriceAsync(currencyCode);

            //Assert
            dolarPoxy.Verify(proxy => proxy.GetCurrenPriceAsync(), Times.Once);
            Assert.NotNull(currencyPrice);
            Assert.Equal(expected.BuyPrice, currencyPrice.BuyPrice);
            Assert.Equal(expected.SalePrice, currencyPrice.SalePrice);
            Assert.Equal(expected.Message, currencyPrice.Message);
        }
    }
}
