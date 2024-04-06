﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using Trips.DAL.Data;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;

namespace Trips.DAL.Services
{
	public class Seeder : ISeeder
	{
		private readonly TripContext _context;
		private readonly ILogger _logger;

		private static readonly Country[] Countries =
		[
			new Country {Name = "Polska" },
			new Country {Name = "Francja" },
			new Country {Name = "Niemcy" },
			new Country {Name = "Włochy" }
		];

		private static readonly City[] Cities =
		[
			new City { Name = "Kraków", Country = Countries[0], CountryId = Countries[0].Id},
			new City { Name = "Gdańsk", Country = Countries[0] , CountryId = Countries[0].Id},
			new City { Name = "Warszawa", Country = Countries[0],CountryId = Countries[0].Id},
			new City { Name = "Paryż", Country = Countries[1], CountryId = Countries[1].Id},
			new City { Name = "Berlin", Country = Countries[2], CountryId = Countries[2].Id}
		];

		private static readonly PointOfIntrest[] PointsOfIntrest =
		[
			new PointOfIntrest { Name = "Wawel", City = Cities[0], },
			new PointOfIntrest { Name = "Żuraw", City = Cities[1], },
			new PointOfIntrest { Name = "Zamek Królewski", City = Cities[2] },
			new PointOfIntrest { Name = "Eiffla", City = Cities[3] },
			new PointOfIntrest { Name = "Brama Brandenburska", City = Cities[4] }
		];

		private static readonly Customer[] Customers =
		[
			new Customer { FirstName = "Jan", LastName = "Kowalski", Email = "jan.kowalski@mail.com" },
			new Customer { FirstName = "Anna", LastName = "Nowak", Email = "anna.nowak@mail.com"},
			new Customer { FirstName = "Piotr", LastName = "Wiśniewski", Email = "piotr.w@mail.com"}
		];

		private static readonly Photo[] Photos = [
			new Photo { FileName = "berlin.jpg", AltText = "Zdjęcie miasta Berlin", Title = "Berlin" },
			new Photo { FileName = "gdansk.jpg", AltText = "Zdjęcie miasta Gdańśk", Title = "Gdańśk" },
			new Photo { FileName = "krakow.jpg", AltText = "Zdjęcie miasta Kraków", Title = "Kraków" },
			new Photo { FileName = "londyn.jpg", AltText = "Zdjęcie miasta Londyn", Title = "Londyn" },
			new Photo { FileName = "paryz.jpg", AltText = "Zdjęcie miasta Paryż", Title = "Paryż" },
			new Photo { FileName = "warszawa.jpg", AltText = "Zdjęcie miasta Warszawa", Title = "Warszawa" }
		];

		private static readonly Trip[] Trips =
		[
			new Trip
		{
			Name = "Wakacje w Krakowie",
			Description = "Wakacje",
			StartDate = new DateOnly(2024, 7, 1),
			EndDate = new DateOnly(2024, 7, 14),
			Price = 2000,
			Seats = 20,
			PointsOfIntrest = new List<PointOfIntrest>
			{
				PointsOfIntrest[0]
			},
			Photo = Photos[2]
		},
		new Trip
		{
			Name = "Wakacje w Gdańsku",
			Description = "Wakacje",
			StartDate = new DateOnly(2024, 8, 1),
			EndDate = new DateOnly(2024, 8, 14),
			Price = 2500,
			Seats = 25,
			PointsOfIntrest = new List<PointOfIntrest>
			{
				PointsOfIntrest[1]
			},
			Photo = Photos[1]
		},
		];

		private static readonly Reservation[] Reservations =
		[
			new Reservation { Trip = Trips[0], Customer = Customers[0], CustomerId = Customers[0].Id, TripId = Trips[0].Id, Confirmed = true},
			new Reservation { Trip = Trips[1], Customer = Customers[1], CustomerId = Customers[1].Id,TripId = Trips[0].Id , Confirmed = true },
			new Reservation { Trip = Trips[0], Customer = Customers[2], CustomerId = Customers[2].Id,TripId = Trips[0].Id , Confirmed = false }
		];

		public Seeder(TripContext context, ILogger logger)
		{
			_context = context;
			_logger = logger;
		}

		public void SeedCountries()
		{
			if (_context.Countries.Any())
			{
				_logger.Information("Countries already seeded. Skipping...");
				return;
			}

			_context.Countries.AddRange(Countries);

		}

		public void SeedCities()
		{
			if (_context.Cities.Any())
			{
				_logger.Information("Cities already seeded. Skipping...");
				return;
			}

			_context.Cities.AddRange(Cities);

		}

		private void SeedPointsOfIntrest()
		{
			if (_context.PointsOfIntrest.Any())
			{
				_logger.Information("Points of interest already seeded. Skipping...");
				return;
			}

			_context.PointsOfIntrest.AddRange(PointsOfIntrest);

		}

		private void SeedTrips()
		{
			if (_context.Trips.Any())
			{
				_logger.Information("Trips already seeded. Skipping...");
				return;
			}

			_context.Trips.AddRange(Trips);
		}

		private void SeedCustomers()
		{
			if (_context.Customers.Any())
			{
				_logger.Information("Customers already seeded. Skipping...");
				return;
			}

			_context.Customers.AddRange(Customers);
		}

		private void SeedReservations()
		{
			if (_context.Reservations.Any())
			{
				_logger.Information("Reservations already seeded. Skipping...");
				return;
			}

			_context.Reservations.AddRange(Reservations);
		}

		private void SeedPhotos()
		{
			if (_context.Photos.Any())
			{
				_logger.Information("Photos already seeded. Skipping...");
				return;
			}

			_context.Photos.AddRange(Photos);
		}

		public void Seed()
		{
			_logger.Information("Seeding database...");

			try
			{
				_context.Database.EnsureCreated();

				SeedCountries();
				SeedCities();
				SeedPointsOfIntrest();
				SeedTrips();
				SeedCustomers();
				SeedReservations();
				SeedPhotos();

				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "An error occurred while seeding the database.");
			}
		}

	}
}
