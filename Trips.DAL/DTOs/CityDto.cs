namespace Trips.DAL.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
