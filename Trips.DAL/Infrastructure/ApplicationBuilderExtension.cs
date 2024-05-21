﻿using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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
using ILogger = Serilog.ILogger;

namespace Trips.DAL.Infrastructure
{
	public static class ApplicationBuilderExtension
	{
		public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<TripContext>(options =>
			{
				var connection = builder.Configuration.GetConnectionString("postgres") ?? throw new InvalidOperationException("Connection string 'Homework_TripsContextConnection' not found.");

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
				.AddScoped<IRepository<City, int>, CityRepository>()
				.AddScoped<IRepository<Country, int>, CountryRepository>()
				.AddScoped<IRepository<Customer, string>, CustomerRepository>()
				.AddScoped<IRepository<Photo, int>, PhotoRepository>()
				.AddScoped<IRepository<PointOfIntrest, int>, PointOfInterestRepository>()
				.AddScoped<IRepository<Reservation, int>, ReservationRepository>()
				.AddScoped<IRepository<Trip, int>, TripRepository>();
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

		public static WebApplicationBuilder AddAuthorization(this WebApplicationBuilder builder)
		{
			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
				options.AddPolicy("User", policy => policy.RequireRole("User"));
			});
			return builder;
		}

		public static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
		{
			builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			ValidatorOptions.Global.LanguageManager.Enabled = false;

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
