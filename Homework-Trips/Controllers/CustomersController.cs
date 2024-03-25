using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
	        _customerService = customerService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var result = _customerService.GetAllDto();
            return View(result);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
	            return NotFound();

            var customer = _customerService.GetByIdDto(id.Value);
            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email")] CustomerDto customerDto)
        {
	        if (!ModelState.IsValid) return View(customerDto);

	        _customerService.InsertCustomer(customerDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _customerService.GetByIdDto(id.Value);

            return View(result);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email")] CustomerDto customerDto)
        {
            if (id != customerDto.Id)
	            return NotFound();

            if (!ModelState.IsValid) return View(customerDto);

            try
            {
	            _customerService.UpdateCustomer(customerDto);
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!CustomerExists(customerDto.Id))
	            {
		            return NotFound();
	            }

	            throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
	            return NotFound();

            var result = _customerService.GetByIdDto(id.Value);

            return View(result);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _customerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
	        return _customerService.Exists(id);
        }
    }
}
