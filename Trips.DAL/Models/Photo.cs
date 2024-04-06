using System.ComponentModel.DataAnnotations;

namespace Trips.DAL.Models
{
	public class Photo
	{
		[Key]
		public int Id { get; set; }
		public required string Title { get; set; }

		[MaxLength(32)]
		public required string FileName { get; set; }

		public required string AltText { get; set; }
	}
}
