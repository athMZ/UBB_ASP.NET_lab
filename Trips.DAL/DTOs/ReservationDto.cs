namespace Trips.DAL.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public required int TripId { get; set; }
        public string? TripName { get; set; }
        public required string CustomerId { get; set; }
        public required bool? Confirmed { get; set; }
    }
}
