using System;
using System.ComponentModel.DataAnnotations;
using LineTen.DataAccess.EntityFramework.Interfaces;

namespace lineten_adapters_inbevtex.Domain.Entities
{
    public class WeatherForecast :IDateTracking
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public int TemperatureC { get; set; }
        [MaxLength(100)]
        public string Summary { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
