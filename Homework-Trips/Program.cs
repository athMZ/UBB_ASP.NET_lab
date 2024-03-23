using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Interfaces;
using Trips.DAL.Services;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;
using Homework_Trips.Data;
using Trips.DAL.Models;
using Trips.DAL.Repositories;

namespace Homework_Trips
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<Homework_TripsContext>(options =>
			    options.UseNpgsql(builder.Configuration.GetConnectionString("Homework_TripsContext") ?? throw new InvalidOperationException("Connection string 'Homework_TripsContext' not found.")));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<TripContext>(options =>
			{
				var connection = builder.Configuration.GetConnectionString("postgres");
				options.UseNpgsql(connection, b =>
				{
					b.MigrationsAssembly("Homework-Trips");
				});
				
			});

			builder.Services.AddScoped<ISeeder, Seeder>();

			builder.Services.AddSingleton<ILogger>(x => new LoggerConfiguration()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.MinimumLevel.Information()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.WriteTo.File("/logs/server-log.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger());

			builder.Services.AddScoped<IRepository<City>, CityRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			using (var scope = app.Services.CreateScope())
			{
				var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
				seeder.Seed();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
