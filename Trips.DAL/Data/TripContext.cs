using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Trips.DAL.Data
{
	public class TripContext : IdentityDbContext<Customer>
	{
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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<City>().HasKey(e => e.Id);
			builder.Entity<Country>().HasKey(e => e.Id);
			builder.Entity<PointOfIntrest>().HasKey(e => e.Id);
			builder.Entity<Photo>().HasKey(e => e.Id);
			builder.Entity<Reservation>().HasKey(e => e.Id);
			builder.Entity<Trip>().HasKey(e => e.Id);
			builder.Entity<Customer>().HasKey(e => e.Id);
		}
	}
}
