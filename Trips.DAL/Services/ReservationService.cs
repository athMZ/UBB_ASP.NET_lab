using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using ILogger = Serilog.ILogger;

namespace Trips.DAL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation, int> _reservationRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ReservationService(IRepository<Reservation, int> reservationRepository, ILogger logger, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            var reservations = _reservationRepository.GetAll();
            var result = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return result;
        }

        public ReservationDto GetById(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            var result = _mapper.Map<ReservationDto>(reservation);
            return result;
        }

        public bool Exists(int id)
        {
            return _reservationRepository.GetById(id) != null;
        }

        public void Delete(int id)
        {
            _reservationRepository.Delete(id);
            _reservationRepository.Save();
        }

        public void Insert(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            _reservationRepository.Insert(reservation);
            _reservationRepository.Save();
        }

        public void Update(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            _reservationRepository.Update(reservation);
            _reservationRepository.Save();
        }

        public int CountReservationsForTrip(int tripId)
        {
            var tripReservations = _reservationRepository.GetAll().Count(r => r.TripId == tripId);
            return tripReservations;
        }
    }
}
