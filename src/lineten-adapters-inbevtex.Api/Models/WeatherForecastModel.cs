using System;
using System.ComponentModel.DataAnnotations;

namespace lineten_adapters_inbevtex.Api.Models
{
    public class WeatherForecastModel
    {
        public Guid Id { get; internal set; }
        public DateTimeOffset Date { get; set; }
        [Required]
        public int? TemperatureC { get; set; }
        public int? TemperatureF
        {
            get => TemperatureC.HasValue ? 32 + (int)(TemperatureC / 0.5556) : default(int?);
        }

        [Required]
        public string Summary { get; set; }
    }
}
