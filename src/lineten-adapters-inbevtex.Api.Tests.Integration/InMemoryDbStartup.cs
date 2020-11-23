using System;
using LineTen.DataAccess.EntityFramework.Database;
using LineTen.DataAccess.EntityFramework.Interfaces;
using LineTen.Integration.Tests.Framework.Authentication;
using lineten_adapters_inbevtex.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace lineten_adapters_inbevtex.Api.Tests.Integration
{
    /// <summary>
    /// A version of the Startup class that allows the integration tests to run without a remote
    /// database, and also eliminates the JWT verification from the HTTP pipeline. This ensures
    /// that we have greater control over the test state
    /// </summary>
    public class InMemoryDbStartup :Startup
    {
        public InMemoryDbStartup(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Overrides the default authentication Schemes with a TestAuthenticationHandler
        /// </summary>
        /// <param name="services"></param>
        protected override void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Test Scheme";
                options.DefaultChallengeScheme = "Test Scheme";
            }).AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("Test Scheme", "Test Auth Display Name",
                o => { });
        }

        /// <summary>
        /// Overrides the default database configuration with an in-memory store.
        /// </summary>
        /// <param name="services"></param>
        protected override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                x.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }, ServiceLifetime.Singleton); //needs to be singleton to work in test-per-class context
            services.AddScoped(typeof(ISaveChangesShim), typeof(DateSaveChangesShim));
        }
    }
}
