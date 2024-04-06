using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface IReservationService : IService<ReservationDto>
{
	public int CountReservationsForTrip(int tripId);
}