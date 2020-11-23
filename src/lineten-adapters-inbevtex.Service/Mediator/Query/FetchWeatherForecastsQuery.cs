using System.Linq;
using lineten_adapters_inbevtex.Domain.Entities;
using MediatR;

namespace lineten_adapters_inbevtex.Service.Mediator.Query
{
    public class FetchWeatherForecastsQuery :IRequest<IQueryable<WeatherForecast>>
    {
    }
}
