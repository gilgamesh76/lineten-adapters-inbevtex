using System;
using System.Reflection;
using LineTen.DataAccess.EntityFramework.Database;
using LineTen.DataAccess.EntityFramework.Interfaces;
using lineten_adapters_inbevtex.Data.Database;
using lineten_adapters_inbevtex.Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace lineten_adapters_inbevtex.Data.Extensions
{

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method that establishes the ExampleDbContext with the specified configuration and uses MySql as the provider
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <param name="loggerFactory">Represents a type used to configure the logging system</param>
        /// <param name="dbOptions">Represents strongly typed environment configuration</param>
        /// <param name="changeTrackerType">We can specify a customized change tracker</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
            ILoggerFactory loggerFactory,
            DbOptions dbOptions, Type changeTrackerType = null)
        {
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
                {
                    Server = dbOptions.DbServer,
                    Password = dbOptions.DbPassword,
                    UserID = dbOptions.DbUsername,
                    Database = dbOptions.DbDatabase
                };
                x.UseMySql(mySqlConnectionStringBuilder.ToString(), y =>
                {
                    y.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).FullName);
                });
                x.EnableSensitiveDataLogging(); // Ensures we get the full SQL output - disable in production
                x.UseLoggerFactory(loggerFactory);
            });

            while (true) //To ensure database server is available before continuing
            {
                try
                {
                    var builder = new MySqlConnectionStringBuilder
                    {
                        Server = dbOptions.DbServer,
                        Password = dbOptions.DbPassword,
                        UserID = dbOptions.DbUsername,
                        Database = dbOptions.DbDatabase
                    };
                    using var connection = new MySqlConnection(builder.ConnectionString);
                    using var command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "select 1";
                    if (command.ExecuteScalar() != DBNull.Value)
                        break;
                }
                catch (MySqlException e)
                {
                    if (e.Number == 1049) //Unknown database - this is ok, we'll scaffold it.
                    {
                        break;
                    }
                }
            }

            services.AddScoped(typeof(ISaveChangesShim), changeTrackerType ?? typeof(DateSaveChangesShim));
            return services;
        }
    }
}

