using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Trips.DAL.Services
{
    public class MainPageService : IMainPageService
    {
        private readonly ITripService _tripService;
        private readonly IReservationService _reservationService;
        private readonly IPhotoService _photoService;
        private readonly IPointOfIntrestService _pointOfIntrestService;

        public MainPageService(ITripService tripService, IReservationService reservationService, IPhotoService photoService, IPointOfIntrestService pointOfIntrestService)
        {
            _tripService = tripService;
            _reservationService = reservationService;
            _photoService = photoService;
            _pointOfIntrestService = pointOfIntrestService;
        }

        public IEnumerable<MainPageCardDto> GetAll()
        {
            var trips = _tripService.GetAll();

            var cards = trips
                .Select(trip =>
                {
                    var reservationCount = trip.ReservationsIds?.Count ?? 0;
                    var altText = "photo.AltText";
                    var photoTitle = "photo.Title";
                    var photoUrl = "photoUrl";

                    if (trip.PhotoId.HasValue)
                    {
	                    var photo = _photoService.GetById(trip.PhotoId.Value);

	                    altText = photo.AltText;
	                    photoTitle = photo.Title;
	                    photoUrl = $"https://localhost:7230/Resources/{photo.FileName}";
                    }

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
                        SeatsReservedPercent = reservationCount / (float)trip.Seats * 100,

                        PhotoAltText = altText,
                        PhotoTitle = photoTitle,
                        PhotoUrl = photoUrl,

                        PointsOfIntrestDtos = trip.PointsOfIntrestIds?.Select(id => _pointOfIntrestService.GetById(id)).ToArray()
                    };
                });

            return cards;

        }

        public MainPageCardDto GetById(int id)
        {
            var trip = _tripService.GetById(id);

            var reservationCount = trip.ReservationsIds?.Count ?? 0;
            var altText = "photo.AltText";
            var photoTitle = "photo.Title";
            var photoUrl = "photoUrl";

            if (trip.PhotoId.HasValue)
            {
	            var photo = _photoService.GetById(trip.PhotoId.Value);

	            altText = photo.AltText;
	            photoTitle = photo.Title;
	            photoUrl = $"https://localhost:7230/Resources/{photo.FileName}";
            }

            var card = new MainPageCardDto
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
	            SeatsReservedPercent = reservationCount / (float)trip.Seats * 100,

	            PhotoAltText = altText,
	            PhotoTitle = photoTitle,
	            PhotoUrl = photoUrl,

	            PointsOfIntrestDtos = trip.PointsOfIntrestIds?.Select(id => _pointOfIntrestService.GetById(id)).ToArray()
            };

            return card;
        }

        public bool Exists(int id)
        {
            return _tripService.Exists(id);
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
