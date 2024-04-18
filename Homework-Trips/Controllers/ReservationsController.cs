using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ICustomerService _customerService;
        private readonly ITripService _tripService;
        private readonly IValidator<ReservationDto> _reservationValidator;

        public ReservationsController(IReservationService reservationService, ICustomerService customerService, ITripService tripService, IValidator<ReservationDto> reservationValidator)
        {
            _reservationService = reservationService;
            _customerService = customerService;
            _tripService = tripService;
            _reservationValidator = reservationValidator;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var result = _reservationService.GetAll();
            return View(result);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _reservationService.GetById(id.Value);
            return View(result);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationDto reservationDto)
        {
	        var result = await _reservationValidator.ValidateAsync(reservationDto);

            if (!ModelState.IsValid || !result.IsValid)
            {
                result.AddToModelState(ModelState);
	            return View(reservationDto);
            }

            _reservationService.Insert(reservationDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _reservationService.GetById(id.Value);

            SetViewBag();
            return View(result);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReservationDto reservationDto)
        {
            if (id != reservationDto.Id)
                return NotFound();

            var result = await _reservationValidator.ValidateAsync(reservationDto);

            if (!ModelState.IsValid || !result.IsValid)
            {
                result.AddToModelState(ModelState);

                SetViewBag();
                return View(reservationDto);
            }

            try
            {
                _reservationService.Update(reservationDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservationDto.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _reservationService.GetById(id.Value);

            return View(result);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _reservationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _reservationService.Exists(id);
        }

        private void SetViewBag()
        {
            ViewBag.TripList = _tripService.GetAll();
            ViewBag.CustomerList = _customerService.GetAll();
        }
    }
}
