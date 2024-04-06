using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.DAL.Models
{
	public class PointOfIntrest
	{
		[Key]
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }

		public virtual City City { get; set; }
		public virtual Photo? Photo { get; set; }

		[ForeignKey("CityId")]
		public int CityId { get; set; }

		[ForeignKey("PhotoId")]
		public int? PhotoId { get; set; }
	}
}
