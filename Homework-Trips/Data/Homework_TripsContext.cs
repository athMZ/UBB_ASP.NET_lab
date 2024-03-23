using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Models;

namespace Homework_Trips.Data
{
    public class Homework_TripsContext : DbContext
    {
        public Homework_TripsContext (DbContextOptions<Homework_TripsContext> options)
            : base(options)
        {
        }

        public DbSet<Trips.DAL.Models.City> City { get; set; } = default!;
        public DbSet<Trips.DAL.Models.Country> Country { get; set; } = default!;
        public DbSet<Trips.DAL.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Trips.DAL.Models.PointOfIntrest> PointOfIntrest { get; set; } = default!;
        public DbSet<Trips.DAL.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<Trips.DAL.Models.Photo> Photo { get; set; } = default!;
        public DbSet<Trips.DAL.Models.Trip> Trip { get; set; } = default!;
    }
}
