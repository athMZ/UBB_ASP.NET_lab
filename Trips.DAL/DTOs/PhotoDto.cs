namespace Trips.DAL.DTOs
{
	public class PhotoDto
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string FileName { get; set; }
		public required string AltText { get; set; }
	}
}
