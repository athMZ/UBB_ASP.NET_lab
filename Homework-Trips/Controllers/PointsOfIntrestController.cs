using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    public class PointsOfIntrestController : Controller
    {
	    private readonly IPointOfIntrestService _pointOfIntrestService;
        private readonly ICityService _cityService;

        public PointsOfIntrestController(IPointOfIntrestService pointOfIntrestService, ICityService cityService)
        {
            _pointOfIntrestService = pointOfIntrestService;
            _cityService = cityService;
        }

        // GET: PointOfIntrests
        public async Task<IActionResult> Index()
        {
	        var result = _pointOfIntrestService.GetAll();
            return View(result);
        }

        // GET: PointOfIntrests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
	        if (id == null)
		        return NotFound();

	        var pointOfIntrest = _pointOfIntrestService.GetById(id.Value);
	        return View(pointOfIntrest);
        }

        // GET: PointOfIntrests/Create
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
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PointOfIntrestDto pointOfIntrestDto)
        {
	        if (!ModelState.IsValid) return View(pointOfIntrestDto);

	        _pointOfIntrestService.Insert(pointOfIntrestDto);
	        return RedirectToAction(nameof(Index));
        }

        // GET: PointOfIntrests/Edit/5
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
        public async Task<IActionResult> Edit(int id, PointOfIntrestDto pointOfIntrestDto)
        {
	        if (id != pointOfIntrestDto.Id)
		        return NotFound();

            if (!ModelState.IsValid)
            {
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
