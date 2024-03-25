using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
	        var result = _countryService.GetAllDto();
            return View(result);
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _countryService.GetByIdDto(id.Value);

            return View(result);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CountryDto countryDto)
        {
	        if (!ModelState.IsValid) return View(countryDto);

	        _countryService.InsertCountry(countryDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _countryService.GetByIdDto(id.Value);

            return View(result);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CountryDto countryDto)
        {
            if (id != countryDto.Id)
	            return NotFound();

            if (!ModelState.IsValid) return View(countryDto);

            try
            {
	            _countryService.UpdateCountry(countryDto);
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _countryService.GetByIdDto(id.Value);

            return View(result);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
