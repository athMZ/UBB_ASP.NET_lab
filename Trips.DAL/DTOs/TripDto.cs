using Trips.DAL.Models;

namespace Trips.DAL.DTOs
{
    public class TripDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Seats { get; set; }
        public int? PhotoId { get; set; }
        public ICollection<int>? ReservationsIds { get; set; }
        public ICollection<int>? PointsOfIntrestIds { get; set; }

    }
}
