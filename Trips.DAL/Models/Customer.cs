using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Trips.DAL.Models
{
	public class Customer : IdentityUser
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }

		public virtual ICollection<Reservation>? Reservations { get; set; }
	}
}
