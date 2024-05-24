using Homework_Trips.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers;

class DataPoint
{
	public DataPoint(string x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public string x { get; set; }
	public int y { get; set; }
}

//[Authorize(Roles = "Admin")]
public class AdminController : Controller
{

	private readonly ICustomerService _customerService;
	private readonly ITripService _tripService;

	public AdminController(ICustomerService customerService, ITripService tripService)
	{
		_customerService = customerService;
		_tripService = tripService;
	}

	// GET
	public IActionResult Index()
	{
		var pieChartData = new DataPoint[]
		{
		new("Polska", 10 ),
		new("Niemcy", 20 ),
		new("Francja", 30 ),
		new("Włochy", 40 ),
		new("Szwecja", 50 )
		};

		var serializedPieChartData = new Tuple<string, string>(
			pieChartData.Select(x => x.x).ToArray().ToJson(),
			pieChartData.Select(x => x.y).ToArray().ToJson()
			);

		var mixedChartData = new DataPoint[]
		{
			new("Magiczny Kraków", 2500),
			new("Wspaniała Warszawa", 3500),
			new("Panoramiczny Paryż", 5000),
			new("Gościnny Gdańsk", 2000),
			new("Widowiskowy Wrocław", 1500),
			new("Sztokholm", 6400),
		};

		var sortedData = mixedChartData.OrderBy(x => x.y);

		var serializedMixedChartData = new Tuple<string, string>(
			sortedData.Select(x => x.x).ToArray().ToJson(),
			sortedData.Select(x => x.y).ToArray().ToJson()
			);

		var priceAvg = Math.Round(mixedChartData.Select(x => x.y).Average(), 2);
		var tmpArray = new double[mixedChartData.Length];
		Array.Fill(tmpArray, priceAvg);
		var serializedPriceAvg = tmpArray.ToJson();

		var adminVm = new AdminPanelViewModel
		{
			CustomersCount = 249,
			TripsCount = 14,
			ReservationsCount = 153,
			CountriesCount = 8,
			SerializedDataForCountryChart = serializedPieChartData,
			SerializedDataForPriceChart = serializedMixedChartData,
			SerializedAveragePrice = serializedPriceAvg,
			DataForReservationBars = new Dictionary<string, int>
			{
				{
					"Magiczny Kraków", 75
				},
				{
					"Wspaniała Warszawa", 45
				},
				{
					"Panoramiczny Paryż", 30
				},
				{
					"Gościnny Gdańsk", 25
				},
				{
					"Widowiskowy Wrocław", 15
				},
				{
					"Sztokholm", 10
				},
			},
			UpcomingTrips =
			[
				new()
				{
					Name = "Magiczny Kraków",
					StartDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(2, 15)),
					EndDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(4, 9)),
				},
				new()
				{
					Name = "Wspaniała Warszawa",
					StartDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(2, 15)),
					EndDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(4, 9)),
				},
				new()
				{
					Name = "Panoramiczny Paryż",
					StartDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(2, 15)),
					EndDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(4, 9)),
				},
				new()
				{
					Name = "Gościnny Gdańsk",
					StartDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(2, 15)),
					EndDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(4, 9)),
				},
				new()
				{
					Name = "Widowiskowy Wrocław",
					StartDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(2, 15)),
					EndDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(4, 9)),
				},
				new()
				{
					Name = "Sztokholm",
					StartDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(2, 15)),
					EndDate = new DateOnly(2024, 05, 25).AddDays(new Random().Next(4, 9)),
				}

			]

		};

		return View(adminVm);
	}
}