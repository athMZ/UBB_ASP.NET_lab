namespace Trips.DAL.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public ICollection<Reservation>? Reservations { get; set; }
	}
}
