using System;
using lineten_adapters_inbevtex.Domain.Entities;
using MediatR;

namespace lineten_adapters_inbevtex.Service.Mediator.Query
{
    public class GetWeatherForecastQuery :IRequest<WeatherForecast>
    {
        public Guid Id { get; set; }
    }
}
