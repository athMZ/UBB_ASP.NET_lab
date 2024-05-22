using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
	public class TripsController : Controller
	{
		private readonly ITripService _tripService;
		private readonly IValidator<TripDto> _tripValidator;

		public TripsController(ITripService tripService, IValidator<TripDto> tripValidator)
		{
			_tripService = tripService;
			_tripValidator = tripValidator;
		}

		// GET: Trips
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var result = _tripService.GetAll();
			return View(result);
		}

		// GET: Trips/Details/5
		[AllowAnonymous]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trip = _tripService.GetById(id.Value);
			return View(trip);
		}

		// GET: Trips/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Trips/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(TripDto tripDto)
		{
			var result = await _tripValidator.ValidateAsync(tripDto);

			if (!ModelState.IsValid || !result.IsValid)
			{
				result.AddToModelState(ModelState);
				return View(tripDto);
			}

			_tripService.Insert(tripDto);
			return RedirectToAction(nameof(Index));
		}

		// GET: Trips/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trip = _tripService.GetById(id.Value);
			return View(trip);
		}

		// POST: Trips/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, TripDto tripDto)
		{
			if (id != tripDto.Id)
			{
				return NotFound();
			}

			var result = await _tripValidator.ValidateAsync(tripDto);

			if (!ModelState.IsValid || !result.IsValid)
			{
				result.AddToModelState(ModelState);
				return View(tripDto);
			}

			try
			{
				_tripService.Update(tripDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TripExists(tripDto.Id))
				{
					return NotFound();
				}

				throw;
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: Trips/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trip = _tripService.GetById(id.Value);

			return View(trip);
		}

		// POST: Trips/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			_tripService.Delete(id);

			return RedirectToAction(nameof(Index));
		}

		private bool TripExists(int id)
		{
			return _tripService.Exists(id);
		}
	}
}
