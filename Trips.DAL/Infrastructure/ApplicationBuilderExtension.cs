using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Trips.DAL.Data;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using Trips.DAL.Repositories;
using Trips.DAL.Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

using ILogger = Serilog.ILogger;

namespace Trips.DAL.Infrastructure
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

        public static WebApplicationBuilder AddInMemoryDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TripContext>(options =>
            {
				options.UseInMemoryDatabase("Trips");
			});

            return builder;
        }


        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IRepository<City>, CityRepository>()
                .AddScoped<IRepository<Country>, CountryRepository>()
                .AddScoped<IRepository<Customer>, CustomerRepository>()
                .AddScoped<IRepository<Photo>, PhotoRepository>()
                .AddScoped<IRepository<PointOfIntrest>, PointOfInterestRepository>()
                .AddScoped<IRepository<Reservation>, ReservationRepository>()
                .AddScoped<IRepository<Trip>, TripRepository>();
            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<ICityService, CityService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IPhotoService, PhotoService>()
                .AddScoped<IPointOfIntrestService, PointOfIntrestService>()
                .AddScoped<IReservationService, ReservationService>()
                .AddScoped<ITripService, TripService>()
                .AddScoped<IMainPageService, MainPageService>()
                .AddScoped<IFileService, FileService>();
            return builder;
        }

        public static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
        {
	        builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddFluentValidationAutoValidation(fv =>
            {
                fv.DisableBuiltInModelValidation = true;
            });

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

        public static WebApplicationBuilder AddConfigure(this WebApplicationBuilder builder)
        {
            var @photoServerParams = builder.Configuration.GetSection(PhotoServerParams.Section);
            builder.Services.Configure<PhotoServerParams>(@photoServerParams);

            return builder;
        }

    }
}
