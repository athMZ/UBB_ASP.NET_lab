namespace Homework_Trips.ViewModels
{
	public enum Destination
	{
		Krakow,
		Warszawa,
		Gdansk,
		Londyn,
		Berlin,
		Paryz
	}

	public class TripDetailsViewModel
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string Description { get; set; }
		public Destination Destination { get; set; }
		public float Price { get; set; }
		public int GroupSize { get; set; }
		public int Reservations { get; set; }
		public DateOnly Date { get; set; }

		public string[] PointsOfIntrest { get; set; } = null!;
		public float PercentReserved => Reservations / (float)GroupSize * 100;
		public string ImagePath => $"/Resources/{Destination.ToString().ToLower()}.jpg";
	}
}
