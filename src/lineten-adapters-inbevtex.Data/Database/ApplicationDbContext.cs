using LineTen.DataAccess.EntityFramework.Database;
using LineTen.DataAccess.EntityFramework.Interfaces;
using lineten_adapters_inbevtex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lineten_adapters_inbevtex.Data.Database
{
    public class ApplicationDbContext : ChangeTrackerDbContext<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ISaveChangesShim changeTracker) : base(options, changeTracker)
        {
        }
        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
