using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface IReservationService : IService<ReservationDto>
{
	public IEnumerable<ReservationDto> GetReservationsForUser(string customerId);

	public int CountReservationsForTrip(int tripId);
}