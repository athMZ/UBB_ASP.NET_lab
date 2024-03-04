namespace BikeRentalWeb.ViewModels
{
	public enum BikeTypeModel { Male, Female, Kids }

	public class BikeDetailsViewModel
	{
		public int Id { get; set; }

		public string Producer { get; set; }
		public string Model { get; set; }
		public int NumberOfGears { get; set; }
		public BikeTypeModel BikeType { get; set; }
		public string Color { get; set; }
	}
}
