namespace Trips.DAL.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public required int TripId { get; set; }
        public required int CustomerId { get; set; }
        public required bool? Confirmed { get; set; }
    }
}
