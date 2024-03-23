namespace Trips.DAL.Models
{
	public class City
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public Photo? Photo { get; set; }
		public required Country Country { get; set; }
	}
}
