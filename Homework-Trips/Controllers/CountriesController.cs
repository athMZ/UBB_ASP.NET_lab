using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IValidator<CountryDto> _countryValidator;

        public CountriesController(ICountryService countryService, IValidator<CountryDto> countryValidator)
        {
	        _countryService = countryService;
	        _countryValidator = countryValidator;
        }

        // GET: Countries
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
	        var result = _countryService.GetAll();
            return View(result);
        }

        // GET: Countries/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _countryService.GetById(id.Value);

            return View(result);
        }

        // GET: Countries/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name")] CountryDto countryDto)
        {

	        var result = await _countryValidator.ValidateAsync(countryDto);

	        if (!ModelState.IsValid || !result.IsValid)
	        {
                result.AddToModelState(ModelState);

		        return View(countryDto);
	        }

	        _countryService.Insert(countryDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _countryService.GetById(id.Value);

            return View(result);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CountryDto countryDto)
        {
            if (id != countryDto.Id)
	            return NotFound();

            var result = await _countryValidator.ValidateAsync(countryDto);

            if (!ModelState.IsValid || !result.IsValid)
            {
                result.AddToModelState(ModelState);
	            return View(countryDto);
            }

            try
            {
	            _countryService.Update(countryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!CountryExists(countryDto.Id))
		            return NotFound();

	            throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _countryService.GetById(id.Value);

            return View(result);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
	        _countryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _countryService.Exists(id);
        }
    }
}
