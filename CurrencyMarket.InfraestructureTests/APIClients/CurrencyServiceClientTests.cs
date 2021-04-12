using CurrencyMarket.Common.Settings;
using CurrencyMarket.Core.DTOs;
using CurrencyMarket.Core.Interfaces.Proxies;
using CurrencyMarket.Infraestructure.APIClients;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CurrencyMarket.InfraestructureTests
{
    public class CurrencyServiceClientTests
    {
        [Fact]
        public async Task get_dolar_price_ShouldReturnData()
        {
            // ARRANGE            
            string jsonContent = @"[""92.000"", ""98.000"",""Actualizada al 9/4/2021 15:00""]";
            CurrencyPrice expected = new CurrencyPrice()
            {
                BuyPrice = 92,
                SalePrice = 98,
                Message = "Actualizada al 9/4/2021 15:00"
            };

            ICurrencyMarketServiceClient client = SetupDolarServiceClient(jsonContent);

            //ACTION
            var price = await client.GetCurrenPriceAsync();

            //ASSERTS
            Assert.NotNull(price);
            Assert.Equal(expected.BuyPrice, price.BuyPrice);
            Assert.Equal(expected.SalePrice, price.SalePrice);
            Assert.Equal(expected.Message, price.Message);

        }

        [Fact]
        public async Task get_real_price_ShouldReturn4thPartOfDolar()
        {
            // ARRANGE            
            string jsonContent = @"[""92.000"", ""98.000"",""Actualizada al 9/4/2021 15:00""]";
            var factoryMock = new Mock<ICurrencyMarketServiceClientFactory>();
            ICurrencyMarketServiceClient dolarClient = SetupDolarServiceClient(jsonContent);
            factoryMock.Setup(a => a.Get(It.IsAny<string>())).Returns(dolarClient);

            CurrencyPrice expected = new CurrencyPrice()
            {
                BuyPrice = 92/4d,
                SalePrice = 98/4d,
                Message = "Actualizada al 9/4/2021 15:00"
            };
            
            ICurrencyMarketServiceClient realClient = new RealCurrencyServiceClient(factoryMock.Object);

            //ACTION
            var price = await realClient.GetCurrenPriceAsync();

            //ASSERTS
            Assert.NotNull(price);
            Assert.Equal(expected.BuyPrice, price.BuyPrice);
            Assert.Equal(expected.SalePrice, price.SalePrice);
            Assert.Equal(expected.Message, price.Message);
        }

        private ICurrencyMarketServiceClient SetupDolarServiceClient(string expectedResponse)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var httpFactoryMock = new Mock<IHttpClientFactory>();
            var settingsMock = new Mock<IOptions<AppSettings>>();
            settingsMock.Setup(a => a.Value).Returns(new AppSettings());

            //Setup mock response of HttpClient Dolar WebAPI.
            handlerMock.Protected()
             .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.IsAny<HttpRequestMessage>(),
               ItExpr.IsAny<CancellationToken>())
             .ReturnsAsync(new HttpResponseMessage()
             {
                 Content = new StringContent(expectedResponse, encoding: System.Text.Encoding.UTF8, "application/json"),
                 StatusCode = System.Net.HttpStatusCode.OK
             }).Verifiable();

            httpFactoryMock.Setup(a => a.CreateClient(It.IsAny<string>())).Returns(new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://www.test.com")
            });

            return new DolarCurrencyServiceClient(httpFactoryMock.Object, settingsMock.Object);
        }
    }
}
