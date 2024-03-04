using Homework_Trips.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Homework_Trips.ViewModels;

namespace Homework_Trips.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IEnumerable<TripDetailsViewModel> _trips = DataSource.Trips;


		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(_trips);
		}

		public IActionResult Details(int id)
		{
			var trip = _trips.FirstOrDefault(x => x.Id == id);
			return View(trip);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
