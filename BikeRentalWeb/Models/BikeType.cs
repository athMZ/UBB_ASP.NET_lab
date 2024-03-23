namespace BikeRentalWeb.Models
{
	public enum UsedBikeTypes
	{
		Mountain,
		Road,
		Electric,
		City
	}

	public class BikeType
	{
		public int Id { get; set; }
		public UsedBikeTypes Type { get; set; }
	}
}
