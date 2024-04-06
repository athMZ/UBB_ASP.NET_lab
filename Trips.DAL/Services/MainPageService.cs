using Microsoft.Extensions.Configuration;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Trips.DAL.Services
{
	public class MainPageService : IMainPageService
	{
		private readonly ITripService _tripService;
		private readonly IReservationService _reservationService;
		private readonly IPhotoService _photoService;

		public MainPageService(ITripService tripService, IReservationService reservationService, IPhotoService photoService)
		{
			_tripService = tripService;
			_reservationService = reservationService;
			_photoService = photoService;
		}

		public IEnumerable<MainPageCardDto> GetAll()
		{
			var trips = _tripService.GetAll();

			var cards = trips
				.Select(trip =>
			{
				int reservationCount = _reservationService.CountReservationsForTrip(trip.Id);
				var photo = _photoService.GetById(trip.Id);
				
				var photoUrl = $"http://localhost:2024/{photo.FileName}";

				return new MainPageCardDto
				{
					Id = trip.Id,
					Name = trip.Name,
					Description = trip.Description ?? string.Empty,

					Price = trip.Price ?? decimal.Zero,

					StartDate = trip.StartDate,
					EndDate = trip.EndDate,

					Seats = trip.Seats,
					Reservations = reservationCount,
					// ReSharper disable once PossibleLossOfFraction
					SeatsReservedPercent = reservationCount / trip.Seats,

					PhotoAltText = photo.AltText,
					PhotoTitle = photo.Title,
					PhotoUrl = photoUrl
				};
			});

			return cards;

		}

		public MainPageCardDto GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Exists(int id)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(MainPageCardDto entity)
		{
			throw new NotImplementedException();
		}

		public void Update(MainPageCardDto entity)
		{
			throw new NotImplementedException();
		}
	}
}
