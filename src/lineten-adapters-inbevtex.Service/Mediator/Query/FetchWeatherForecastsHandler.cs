using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LineTen.DataAccess.EntityFramework.Repository;
using lineten_adapters_inbevtex.Domain.Entities;
using MediatR;

namespace lineten_adapters_inbevtex.Service.Mediator.Query
{
    public class FetchWeatherForecastsHandler : IRequestHandler<FetchWeatherForecastsQuery, IQueryable<WeatherForecast>>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public FetchWeatherForecastsHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<IQueryable<WeatherForecast>> Handle(FetchWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.Query();
            return Task.FromResult(result);
        }
    }
}
