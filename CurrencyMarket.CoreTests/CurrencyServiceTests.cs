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
        public async Task get_current_price_ShouldCallServiceClient()
        {
            //Arrange
            string currencyCode = "dolar";
            var dolarServiceClient = new Mock<ICurrencyMarketServiceClient>();
            var proxyFactory = new Mock<ICurrencyMarketServiceClientFactory>();

            var expected = new CurrencyPrice()
            {
                BuyPrice = 58,
                Message = "Test of message",
                SalePrice = 60
            };
            dolarServiceClient.Setup(a => a.GetCurrenPriceAsync()).Returns(()=>Task.FromResult(expected));
            proxyFactory.Setup(a => a.Get(It.IsAny<string>())).Returns(dolarServiceClient.Object);
            ICurrencyService currencyService = new CurrencyService(proxyFactory.Object);

            //Action
            CurrencyPrice currencyPrice = await currencyService.GetCurrencyPriceAsync(currencyCode);

            //Assert
            dolarServiceClient.Verify(proxy => proxy.GetCurrenPriceAsync(), Times.Once);
            Assert.NotNull(currencyPrice);
            Assert.Equal(expected.BuyPrice, currencyPrice.BuyPrice);
            Assert.Equal(expected.SalePrice, currencyPrice.SalePrice);
            Assert.Equal(expected.Message, currencyPrice.Message);
        }
    }
}
