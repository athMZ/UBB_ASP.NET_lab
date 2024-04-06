using System.ComponentModel.DataAnnotations;

namespace Trips.DAL.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }

		[EmailAddress]
		public required string Email { get; set; }

		public virtual ICollection<Reservation>? Reservations { get; set; }
	}
}
