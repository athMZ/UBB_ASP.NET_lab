using Homework_Trips.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Homework_Trips.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMainPageService _mainPageService;
        private readonly ILogger<HomeController> _logger;

        private readonly IEnumerable<TripDetailsViewModel> _trips = DataSource.Trips;

        public HomeController(ILogger<HomeController> logger, IMainPageService mainPageService)
        {
            _logger = logger;
            _mainPageService = mainPageService;
        }

        public IActionResult Index()
        {
            var result = _mainPageService.GetAll();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var result = _mainPageService.GetById(id);
			return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
