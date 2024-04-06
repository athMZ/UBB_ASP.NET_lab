using Microsoft.EntityFrameworkCore;
using Trips.DAL.Models;

namespace Homework_Trips.Data
{
	public class Homework_TripsContext : DbContext
	{
		public Homework_TripsContext(DbContextOptions<Homework_TripsContext> options)
			: base(options)
		{
		}

		public DbSet<City> City { get; set; } = default!;
		public DbSet<Country> Country { get; set; } = default!;
		public DbSet<Customer> Customer { get; set; } = default!;
		public DbSet<PointOfIntrest> PointOfIntrest { get; set; } = default!;
		public DbSet<Reservation> Reservation { get; set; } = default!;
		public DbSet<Photo> Photo { get; set; } = default!;
		public DbSet<Trip> Trip { get; set; } = default!;

	}
}
