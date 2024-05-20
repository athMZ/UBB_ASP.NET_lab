using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
	public class CitiesController : Controller
	{
		private readonly ICityService _cityService;
		private readonly ICountryService _countryService;
		private readonly IValidator<CityDto> _cityValidator;

		public CitiesController(ICityService cityService, ICountryService countryService, IValidator<CityDto> cityValidator)
		{
			_cityService = cityService;
			_countryService = countryService;
			_cityValidator = cityValidator;
		}

		// GET: Cities
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var result = _cityService.GetAll();
			return View(result);
		}

		// GET: Cities/Details/5
		[AllowAnonymous]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _cityService.GetById(id.Value);
			return View(result);
		}

		// GET: Cities/Create
		[Authorize(Roles = "Admin")]
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
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(CityDto cityDto)
		{
			var result = await _cityValidator.ValidateAsync(cityDto);

			if (!result.IsValid || !ModelState.IsValid)
			{
				result.AddToModelState(ModelState);
				SetCountriesViewBag();

				return View(cityDto);
			}

			_cityService.Insert(cityDto);

			return RedirectToAction(nameof(Index));
		}

		// GET: Cities/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _cityService.GetById(id.Value);

			SetCountriesViewBag();
			return View(result);
		}

		// POST: Cities/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, CityDto cityDto)
		{
			if (id != cityDto.Id)
				return NotFound();

			var result = await _cityValidator.ValidateAsync(cityDto);
			if (!result.IsValid || !ModelState.IsValid)
			{
				result.AddToModelState(ModelState);
				SetCountriesViewBag();

				return View(cityDto);
			}

			try
			{
				_cityService.Update(cityDto);
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
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _cityService.GetById(id.Value);

			return View(result);
		}

		// POST: Cities/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]

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
			ViewBag.CountryList = _countryService.GetAll();
		}
	}
}
