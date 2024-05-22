using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Trips.DAL.Models;

namespace Trips.DAL.Infrastructure;

public class Startup
{
	private readonly string[]? _adminUsernames;

	private readonly string? _defaultAdminEmail;
	private readonly string? _defaultAdminPassword;

	private readonly string? _defaultUserEmail;
	private readonly string? _defaultUserPassword;

	public Startup(IConfiguration configuration)
	{
		_adminUsernames = configuration.GetSection("AdminUsernames").Get<string[]>();

		_defaultAdminEmail = configuration.GetSection("DefaultAdminEmail").Get<string>();
		_defaultAdminPassword = configuration.GetSection("DefaultAdminPassword").Get<string>();

		_defaultUserEmail = configuration.GetSection("DefaultUserEmail").Get<string>();
		_defaultUserPassword = configuration.GetSection("DefaultUserPassword").Get<string>();
	}


	public RoleManager<IdentityRole> Configure(RoleManager<IdentityRole> roleManager, UserManager<Customer> userManager)
	{
		EnsureRolesCreated(roleManager).Wait();
		EnsureAdminCreated(userManager).Wait();
		EnsureUserCreated(userManager).Wait();
		EnsureUsersHaveRoles(userManager).Wait();

		return roleManager;
	}

	private async Task EnsureRolesCreated(RoleManager<IdentityRole> roleManager)
	{
		// Check if the Admin role exists, if not, create it
		if (!await roleManager.RoleExistsAsync("Admin"))
			await roleManager.CreateAsync(new IdentityRole("Admin"));

		// Check if the User role exists, if not, create it
		if (!await roleManager.RoleExistsAsync("User"))
			await roleManager.CreateAsync(new IdentityRole("User"));
	}

	async Task EnsureUsersHaveRoles(UserManager<Customer> userManager)
	{
		if (_adminUsernames is null || _adminUsernames.Length < 1) return;

		var users = await userManager.Users.ToListAsync();

		foreach (var user in users)
		{
			if (_adminUsernames.Contains(user.UserName))
			{
				await userManager.AddToRoleAsync(user, "Admin");
			}
			else
			{
				await userManager.AddToRoleAsync(user, "User");
			}
		}
	}

	async Task EnsureAdminCreated(UserManager<Customer> userManager)
	{
		var adminEmail = _defaultAdminEmail;
		var adminPassword = _defaultAdminPassword;

		if (adminEmail is null || adminPassword is null) return;

		var user = await userManager.FindByEmailAsync(adminEmail);
		if (user is not null) return;

		//Create admin if not present
		var adminUser = new Customer
		{
			UserName = adminEmail,
			Email = adminEmail,
			FirstName = "Admin",
			LastName = "Admin",
			EmailConfirmed = true
		};

		var result = await userManager.CreateAsync(adminUser, adminPassword);
		if (result.Succeeded)
		{
			await userManager.AddToRoleAsync(adminUser, "Admin");
		}
		else
		{
			// Handle the error here
			foreach (var error in result.Errors)
			{
				Console.WriteLine(error.Description);
			}
		}

	}

	async Task EnsureUserCreated(UserManager<Customer> userManager)
	{
		var userEmail = _defaultUserEmail;
		var userPassword = _defaultUserPassword;

		if (userEmail is null || userPassword is null) return;


		var user = await userManager.FindByEmailAsync(userEmail);
		if (user != null) return;

		var newUser = new Customer
		{
			UserName = userEmail,
			Email = userEmail,
			FirstName = "Jan",
			LastName = "Userowy",
			EmailConfirmed = true
		};

		var result = await userManager.CreateAsync(newUser, userPassword);
		if (result.Succeeded)
		{
			await userManager.AddToRoleAsync(newUser, "User");
		}
		else
		{
			// Handle the error here
			foreach (var error in result.Errors)
			{
				Console.WriteLine(error.Description);
			}
		}
	}

}