using AutoMapper;
using lineten_adapters_inbevtex.Api.Models;
using lineten_adapters_inbevtex.Domain.Entities;

namespace lineten_adapters_inbevtex.Api.Mapper
{
    /// <summary>
    /// The AutoMapper profile between the domain entity and the web api model
    /// </summary>
    public class WeatherForecastProfile :Profile
    {
        /// <inheritdoc />
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecastModel, WeatherForecast>()
                .ForMember(x=> x.CreatedDate, map=> map.Ignore())
                .ForMember(x=> x.UpdatedDate, map=> map.Ignore());

            CreateMap<WeatherForecast, WeatherForecastModel>();
        }
    }
}
