namespace Trips.DAL.DTOs
{
	public class CustomerDto
	{
		public string Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
	}
}
