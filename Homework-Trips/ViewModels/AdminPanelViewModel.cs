using Trips.DAL.DTOs;

namespace Homework_Trips.ViewModels
{
	public class AdminPanelViewModel
	{
		public int CustomersCount { get; set; }
		public int TripsCount { get; set; }
		public int ReservationsCount { get; set; }
		public int CountriesCount { get; set; }

		public Tuple<string, string>? SerializedDataForCountryChart { get; set; }
		public Tuple<string, string>? SerializedDataForPriceChart { get; set; }
		public string? SerializedAveragePrice { get; set; }

		public Dictionary<string, int>? DataForReservationBars { get; set; }

		public TripDto[] UpcomingTrips { get; set; }
	}
}
