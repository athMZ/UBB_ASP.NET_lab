using Trips.DAL.Interfaces;
using Trips.DAL.Infrastructure;

//TODO: Revamp models to simplify ids and relationships
//TODO: Add Home Service to display main page using cards
//TODO: Add File Controller to upload and images
//TODO: Add File Service to save images//https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/sending-html-form-data-part-2
//https://stackoverflow.com/questions/40629947/receive-file-and-other-form-data-together-in-asp-net-core-web-api-boundary-base

//TODO: Scaffold Identity using postgresql
//TODO: Change DB context to use Identity

namespace Homework_Trips
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder
				//.AddDbContext()
				.AddInMemoryDbContext()
				.AddRepositories()
				.AddServices()
				.AddLogger()
				.AddSeeder()
				.AddValidators()
				.AddAutoMapper();

			// Add services to the container.
			builder.Services.AddControllersWithViews();

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

			//TODO: Map Razor Pages

			app.Run();
		}
	}
}
