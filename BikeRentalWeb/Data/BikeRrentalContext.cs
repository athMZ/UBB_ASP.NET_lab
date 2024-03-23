using BikeRentalWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalWeb.Data
{
	public class BikeRentalDbContext : DbContext
	{
		public BikeRentalDbContext(DbContextOptions<BikeRentalDbContext> options) : base(options)
		{
		}

		public DbSet<Bike> Bikes { get; set; }
	}
}
