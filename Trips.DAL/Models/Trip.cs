using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.DAL.Models
{
	public class Trip
	{
		[Key]
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }

		[DataType(DataType.Date)]
		public DateOnly StartDate { get; set; }

		[DataType(DataType.Date)]
		public DateOnly EndDate { get; set; }

		[DataType(DataType.Currency)]
		public decimal? Price { get; set; }

		public int Seats { get; set; }

		public virtual Photo? Photo { get; set; }
		public virtual ICollection<Reservation>? Reservations { get; set; }
		public virtual ICollection<PointOfIntrest>? PointsOfIntrest { get; set; }

        [ForeignKey("PhotoId")]
		public int? PhotoId { get; set; }
	}
}
