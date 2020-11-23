using System.Net;
using System.Threading.Tasks;
using LineTen.Integration.Tests.Framework.Attributes;
using LineTen.Integration.Tests.Framework.Fixtures;
using lineten_adapters_inbevtex.Data.Database;
using lineten_adapters_inbevtex.Domain.Entities;
using Newtonsoft.Json.Linq;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace lineten_adapters_inbevtex.Api.Tests.Integration.Controllers.WeatherForecastController
{
    [TestCaseOrderer(SequenceTestCaseOrderer.OrdererTypeName, SequenceTestCaseOrderer.OrdererAssemblyName)]
    public class when_getting_all_weather_forecasts :IClassFixture<LoopbackTestFixture<InMemoryDbStartup>> //https://xunit.net/docs/shared-context
    {
        private readonly LoopbackTestFixture<InMemoryDbStartup> _fixture;

        public when_getting_all_weather_forecasts(LoopbackTestFixture<InMemoryDbStartup> fixture)
        {
            _fixture = fixture;
            var applicationDbContext = _fixture.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            applicationDbContext.WeatherForecasts.Add(new WeatherForecast());
            applicationDbContext.SaveChanges();
        }

        [Fact]
        public async Task it_should_return_a_list_of_forecasts()
        {
            var response = await _fixture.HttpClient.GetAsync($"weatherforecast");
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jToken = JToken.Parse(content);
            Assert.Equal(JTokenType.Array, jToken.Type);
            Assert.NotEmpty(jToken.AsJEnumerable());
        }
    }
}
