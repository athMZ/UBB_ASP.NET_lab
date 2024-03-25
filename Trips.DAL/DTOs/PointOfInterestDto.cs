namespace Trips.DAL.DTOs
{
	public class PointOfIntrestDto
	{
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? PhotoId { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
	}
}
