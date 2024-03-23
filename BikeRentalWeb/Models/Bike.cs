namespace BikeRentalWeb.Models
{
	public class Bike
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public decimal PricePerHour { get; set; }

		public Brand Brand { get; set; }
		public BikeType Type { get; set; }
	}
}
