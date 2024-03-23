using NuGet.Protocol.Core.Types;

namespace Trips.DAL.Models
{
	public class Reservation
	{
		public int Id { get; set; }
		public required Trip Trip { get; set; }
		public required Customer Customer { get; set; }
		public required bool? Confirmed { get; set; }
	}

}
