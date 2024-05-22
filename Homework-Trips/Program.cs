using Microsoft.AspNetCore.Identity;
using Trips.DAL.Data;
using Trips.DAL.Interfaces;
using Trips.DAL.Infrastructure;
using Trips.DAL.Models;

//TODO: Add File Controller to upload and images
//TODO: Add File Service to save images//https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/sending-html-form-data-part-2
//https://stackoverflow.com/questions/40629947/receive-file-and-other-form-data-together-in-asp-net-core-web-api-boundary-base

namespace Homework_Trips
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder
                .AddDbContext()
                //.AddInMemoryDbContext()
                .AddRepositories()
                .AddServices()
                .AddLogger()
                .AddSeeder()
                .AddValidators()
                .AddAutoMapper();

            // Add Identity to the container - can't move to an extension method
            builder.Services.AddIdentity<Customer, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TripContext>()
                .AddDefaultTokenProviders();

            //Add Razor Pages to the container
            builder.Services.AddRazorPages();

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

                var startup = new Startup(app.Configuration);

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Customer>>();

                startup.Configure(roleManager, userManager);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
