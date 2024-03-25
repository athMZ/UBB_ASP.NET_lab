using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Trips.DAL.Data;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using Trips.DAL.Repositories;
using Trips.DAL.Services;
using ILogger = Serilog.ILogger;

namespace Homework_Trips.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TripContext>(options =>
            {
                var connection = builder.Configuration.GetConnectionString("postgres");
                options.UseNpgsql(connection, b =>
                {
                    b.MigrationsAssembly("Homework-Trips");
                });

            });
            return builder;
        }

        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IRepository<City>, CityRepository>()
                .AddScoped<IRepository<Country>, CountryRepository>();
            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
	        builder.Services
		        .AddScoped<ICountryService, CountryService>()
		        .AddScoped<ICityService, CityService>();
	        return builder;
        }

        public static WebApplicationBuilder AddSeeder(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISeeder, Seeder>();
            return builder;
        }

        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ILogger>(x => new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("/logs/server-log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger());
            return builder;
        }

        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return builder;
        }
    }
}
