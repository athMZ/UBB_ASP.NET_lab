using BikeRentalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BikeRentalWeb.ViewModels;

namespace BikeRentalWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IEnumerable<BikeDetailsViewModel> _bikes = new List<BikeDetailsViewModel>
		{
			new()
			{
				Id = 0,
				Producer = "Giant",
				Model = "TCRS-1",
				NumberOfGears = 24,
				BikeType = BikeTypeModel.Male,
				Color = "Black"
			},
			new()
			{
				Id = 1,
				Producer = "Midi",
				Model = "ASD-1",
				NumberOfGears = 16,
				BikeType = BikeTypeModel.Male,
				Color = "Silver"
			},
			new()
			{
				Id = 2,
				Producer = "City",
				Model = "ASD-2",
				NumberOfGears = 8,
				BikeType = BikeTypeModel.Female,
				Color = "Red"
			},
			new()
			{
				Id = 2,
				Producer = "Kid",
				Model = "Skibi-1",
				NumberOfGears = 8,
				BikeType = BikeTypeModel.Kids,
				Color = "White"
			}
		};

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(_bikes);
		}


		public IActionResult Details(int id)
		{
			var bike = _bikes.FirstOrDefault(x => x.Id == id);
			return View(bike);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
