using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using lineten_adapters_inbevtex.Api.Models;
using lineten_adapters_inbevtex.Domain.Entities;
using lineten_adapters_inbevtex.Service.Mediator.Command;
using lineten_adapters_inbevtex.Service.Mediator.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lineten_adapters_inbevtex.Api.Controllers
{
    /// <summary>
    /// Controls the weather!
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        /// <inheritdoc />
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all weather forecasts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecastModel>>> GetAsync()
        {
            _logger.LogTrace("Handling GetAsync");
            var weatherForecasts  = await _mediator.Send(new FetchWeatherForecastsQuery());
            var results = weatherForecasts.ProjectTo<WeatherForecastModel>(_mapper.ConfigurationProvider).ToList();
            return Ok(results);
        }

        /// <summary>
        /// Returns a single forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<WeatherForecastModel>>> GetOneAsync(Guid id)
        {
            _logger.LogTrace("Handling GetOne");
            var weatherForecasts  = await _mediator.Send(new GetWeatherForecastQuery{Id = id});
            if (weatherForecasts == null)
                return NotFound();
            return Ok(_mapper.Map<WeatherForecastModel>(weatherForecasts));
        }


        /// <summary>
        /// Creates a new weather forecast
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<WeatherForecastModel>> CreateAsync([FromBody] WeatherForecastModel model)
        {
            _logger.LogTrace("Handling CreateAsync");
            var weatherForecast = await _mediator.Send(new CreateWeatherForecastCommand
            {
                WeatherForecast = _mapper.Map<WeatherForecast>(model)
            });
            return CreatedAtAction(nameof(GetOneAsync),new{id = weatherForecast.Id}, weatherForecast);
        }

        /// <summary>
        /// Deletes a weather forecast
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        //[Authorize(Roles = "change-me")]
        [Authorize] //Authorize on its own just requires an authenticated user
        public Task<ActionResult<WeatherForecastModel>> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
