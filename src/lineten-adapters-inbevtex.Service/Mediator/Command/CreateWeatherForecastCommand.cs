using lineten_adapters_inbevtex.Domain.Entities;
using MediatR;

namespace lineten_adapters_inbevtex.Service.Mediator.Command
{
    public class CreateWeatherForecastCommand :IRequest<WeatherForecast>{
        public WeatherForecast WeatherForecast { get; set; }
    }
}
