using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.DAL.Models
{
	public class Reservation
	{
		[Key]
		public int Id { get; set; }
		public required bool? Confirmed { get; set; }

		public virtual Trip Trip { get; set; }
		public virtual Customer Customer { get; set; }
		
		[ForeignKey("TripId")]
        public int TripId { get; set; }

		[ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
    }

}
