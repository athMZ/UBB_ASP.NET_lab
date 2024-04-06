using System.ComponentModel.DataAnnotations;

namespace Trips.DAL.Models
{
	public class Country
	{
		[Key]
		public int Id { get; set; }
		public required string Name { get; set; }

		public virtual ICollection<City> Cities { get; set; }
	}
}
