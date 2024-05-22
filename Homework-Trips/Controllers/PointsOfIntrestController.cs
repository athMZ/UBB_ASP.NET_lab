using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    public class PointsOfIntrestController : Controller
    {
	    private readonly IPointOfIntrestService _pointOfIntrestService;
        private readonly ICityService _cityService;
        private readonly IValidator<PointOfIntrestDto> _pointOfIntrestValidator;

        public PointsOfIntrestController(IPointOfIntrestService pointOfIntrestService, ICityService cityService, IValidator<PointOfIntrestDto> pointOfIntrestValidator)
        {
            _pointOfIntrestService = pointOfIntrestService;
            _cityService = cityService;
            _pointOfIntrestValidator = pointOfIntrestValidator;
        }

        // GET: PointOfIntrests
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
	        var result = _pointOfIntrestService.GetAll();
            return View(result);
        }

        // GET: PointOfIntrests/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
	        if (id == null)
		        return NotFound();

	        var pointOfIntrest = _pointOfIntrestService.GetById(id.Value);
	        return View(pointOfIntrest);
        }

        // GET: PointOfIntrests/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            SetCitiesViewBag();
            return View();
        }

        // POST: PointOfIntrests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(PointOfIntrestDto pointOfIntrestDto)
        {
            var result = await _pointOfIntrestValidator.ValidateAsync(pointOfIntrestDto);

	        if (!ModelState.IsValid || !result.IsValid)
	        {
                result.AddToModelState(ModelState);

                SetCitiesViewBag();
		        return View(pointOfIntrestDto);
	        }

	        _pointOfIntrestService.Insert(pointOfIntrestDto);
	        return RedirectToAction(nameof(Index));
        }

        // GET: PointOfIntrests/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
	        if (id == null)
		        return NotFound();

	        var result = _pointOfIntrestService.GetById(id.Value);

            SetCitiesViewBag();
	        return View(result);
        }

        // POST: PointOfIntrests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, PointOfIntrestDto pointOfIntrestDto)
        {
	        if (id != pointOfIntrestDto.Id)
		        return NotFound();

            var result = await _pointOfIntrestValidator.ValidateAsync(pointOfIntrestDto);

            if (!ModelState.IsValid || !result.IsValid)
            {
                result.AddToModelState(ModelState);

                SetCitiesViewBag();
                return View(pointOfIntrestDto);
            }

	        try
	        {
		        _pointOfIntrestService.Update(pointOfIntrestDto);
	        }
	        catch (DbUpdateConcurrencyException)
	        {
		        if (!PointOfIntrestExists(pointOfIntrestDto.Id))
		        {
			        return NotFound();
		        }

		        throw;
	        }
	        return RedirectToAction(nameof(Index));
        }

        // GET: PointOfIntrests/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
	        if (id == null)
		        return NotFound();

	        var result = _pointOfIntrestService.GetById(id.Value);

	        return View(result);
        }

        // POST: PointOfIntrests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
	        _pointOfIntrestService.Delete(id);
	        return RedirectToAction(nameof(Index));
        }

        private bool PointOfIntrestExists(int id)
		{
	        return _pointOfIntrestService.Exists(id);
        }

        private void SetCitiesViewBag()
        {
            ViewBag.CityList = _cityService.GetAll();
        }
    }
}
