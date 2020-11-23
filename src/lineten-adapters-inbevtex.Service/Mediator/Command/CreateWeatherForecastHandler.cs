using System.Threading;
using System.Threading.Tasks;
using LineTen.DataAccess.EntityFramework.Repository;
using lineten_adapters_inbevtex.Domain.Entities;
using MediatR;

namespace lineten_adapters_inbevtex.Service.Mediator.Command
{
    public class CreateWeatherForecastHandler : IRequestHandler<CreateWeatherForecastCommand, WeatherForecast>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public CreateWeatherForecastHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecast> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var result = _repository.Add(request.WeatherForecast);
            return Task.FromResult(result);
        }
    }
}
