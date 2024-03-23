namespace Trips.DAL.Models
{
	public class Trip
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public DateOnly StartDate { get; set; }
		public DateOnly EndDate { get; set; }
		public string? Description { get; set; }
		public decimal? Price { get; set; }
		public int Seats { get; set; }
		public Photo? Photo { get; set; }
		public ICollection<Reservation>? Reservations { get; set; }
		public ICollection<PointOfIntrest>? PointsOfIntrest { get; set; }
	}
}
