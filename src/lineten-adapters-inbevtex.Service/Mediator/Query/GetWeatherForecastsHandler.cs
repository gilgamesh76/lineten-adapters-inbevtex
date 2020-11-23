using System.Threading;
using System.Threading.Tasks;
using LineTen.DataAccess.EntityFramework.Repository;
using lineten_adapters_inbevtex.Domain.Entities;
using MediatR;

namespace lineten_adapters_inbevtex.Service.Mediator.Query
{
    public class GetWeatherForecastsHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecast>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public GetWeatherForecastsHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }
        public Task<WeatherForecast> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.Find(request.Id);
            return Task.FromResult(result);
        }
    }
}
