using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Trips.DAL.Infrastructure;

public class Startup
{
	private readonly string[]? _adminUsernames;

	public Startup(IConfiguration configuration)
	{
		_adminUsernames = configuration.GetSection("AdminUsernames").Get<string[]>();
	}


	public RoleManager<IdentityRole> Configure(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
	{
		EnsureRolesCreated(roleManager).Wait();
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

	async Task EnsureUsersHaveRoles(UserManager<IdentityUser> userManager)
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

}