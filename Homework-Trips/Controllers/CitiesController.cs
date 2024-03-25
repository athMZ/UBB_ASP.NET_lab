using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
	public class CitiesController : Controller
	{
		private readonly ICityService _cityService;
		private readonly ICountryService _countryService;

		public CitiesController(ICityService cityService, ICountryService countryService)
		{
			_cityService = cityService;
			_countryService = countryService;
		}

		// GET: Cities
		public async Task<IActionResult> Index()
		{
			var result = _cityService.GetAllDto();
			return View(result);
		}

		// GET: Cities/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _cityService.GetByIdDto(id.Value);
			return View(result);
		}

		// GET: Cities/Create
		public IActionResult Create()
		{
			SetCountriesViewBag();
			return View();
		}

		// POST: Cities/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CityDto cityDto)
		{
			if (!ModelState.IsValid) return View(cityDto);

			var countryDto = _countryService.GetByIdDto(cityDto.CountryId);
			_cityService.InsertCity(cityDto, countryDto);

			return RedirectToAction(nameof(Index));
		}

		// GET: Cities/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _cityService.GetByIdDto(id.Value);

			SetCountriesViewBag();
			return View(result);
		}

		// POST: Cities/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, CityDto cityDto)
		{
			if (id != cityDto.Id)
				return NotFound();

			if (!ModelState.IsValid)
			{
				SetCountriesViewBag();
				return View(cityDto);
			}

			var countryDto = _countryService.GetByIdDto(cityDto.CountryId);

			try
			{
				_cityService.UpdateCity(cityDto, countryDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CityExists(cityDto.Id))
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

			var result = _cityService.GetByIdDto(id.Value);

			return View(result);
		}

		// POST: Cities/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			_cityService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

		private bool CityExists(int id)
		{
			return _cityService.Exists(id);
		}
		private void SetCountriesViewBag()
		{
			ViewBag.CountryList = _countryService.GetAllDto();
		}
	}
}
