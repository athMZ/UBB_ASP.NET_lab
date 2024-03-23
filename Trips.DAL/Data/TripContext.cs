using Microsoft.EntityFrameworkCore;
using Trips.DAL.Models;

namespace Trips.DAL.Data
{
	public class TripContext : DbContext
	{
		public TripContext()
		{
			
		}

		public TripContext(DbContextOptions<TripContext> options) : base(options)
		{
		}

		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<PointOfIntrest> PointsOfIntrest { get; set; }
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}
}
