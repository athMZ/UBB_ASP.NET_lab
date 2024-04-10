namespace Trips.DAL.DTOs
{
	public class MainPageCardDto
	{
		public required int Id { get; set; }
		public required string Name { get; set; }

		public required string Description { get; set; }
		public decimal Price { get; set; }

		public DateOnly StartDate { get; set; }
		public DateOnly EndDate { get; set; }

		public int Seats { get; set; }
		public int Reservations { get; set; }
		public float SeatsReservedPercent { get; set; }

		public string PhotoTitle { get; set; }
		public string PhotoUrl { get; set; }
		public string PhotoAltText { get; set; }

		public PointOfIntrestDto[]? PointsOfIntrestDtos { get; set; }

	}
}
