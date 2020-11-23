using System.Threading;
using System.Threading.Tasks;
using LineTen.DataAccess.EntityFramework.Repository;
using lineten_adapters_inbevtex.Domain.Entities;
using lineten_adapters_inbevtex.Service.Mediator.Command;
using LineTen.Unit.Tests.Framework;
using Moq;
using Xunit;

namespace lineten_adapters_inbevtex.Service.Tests.Unit
{
    public class when_creating_a_new_weather_forecast : WithSubject<CreateWeatherForecastHandler>
    {
        [Fact]
        public async Task it_should_add_the_object_to_the_repository()
        {
            await Subject.Handle(new CreateWeatherForecastCommand(), CancellationToken.None);
            The<IRepository<WeatherForecast>>().Verify(x => x.Add(It.IsAny<WeatherForecast>()),Times.Once);
        }
    }
}
