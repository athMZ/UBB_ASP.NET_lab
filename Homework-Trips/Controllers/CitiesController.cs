using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using ILogger = Serilog.ILogger;


namespace Homework_Trips.Controllers
{
	public class CitiesController : Controller
	{
		private readonly IRepository<City> _repository;
		private readonly ILogger _logger;

		public CitiesController(IRepository<City> repository, ILogger logger)
		{
			_repository = repository;
			_logger = logger;
		}

		// GET: Cities
		public async Task<IActionResult> Index()
		{
			var cities = _repository.GetAll();
			return View(cities);
		}

		// GET: Cities/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var city = _repository.GetById(id.Value);
			return View(city);
		}

		// GET: Cities/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Cities/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description")] City city)
		{
			if (!ModelState.IsValid) return View(city);

			_repository.Insert(city);
			_repository.Save();
			return RedirectToAction(nameof(Index));
		}

		// GET: Cities/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var city = _repository.GetById(id.Value);
			return View(city);
		}

		// POST: Cities/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] City city)
		{
			if (id != city.Id)
				return NotFound();
			
/*			var cityEntity = _repository.GetById(id);
			city.Country = cityEntity?.Country;*/

			if (!ModelState.IsValid) return View(city);

			try
			{
				_repository.Update(city);
				_repository.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CityExists(city.Id))
					return NotFound();
				throw;
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: Cities/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var city = _repository.GetById(id.Value);
			return View(city);
		}

		// POST: Cities/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			_repository.Delete(id);
			_repository.Save();

			return RedirectToAction(nameof(Index));
		}

		private bool CityExists(int id)
		{
			return _repository.Exists(id);
		}
	}
}
