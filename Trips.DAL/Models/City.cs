using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.DAL.Models
{
	public class City
	{
		[Key]
		public int Id { get; set; }

		public required string Name { get; set; }
		public string? Description { get; set; }

		public virtual Country Country { get; set; }
		public virtual Photo? Photo { get; set; }

		[ForeignKey("CountryId")]
		public int CountryId { get; set; }

		[ForeignKey("PhotoId")]
		public int? PhotoId { get; set; }
	}
}
