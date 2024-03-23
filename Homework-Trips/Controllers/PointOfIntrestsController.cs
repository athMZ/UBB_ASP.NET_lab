using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homework_Trips.Data;
using Trips.DAL.Models;

namespace Homework_Trips.Controllers
{
    public class PointOfIntrestsController : Controller
    {
        private readonly Homework_TripsContext _context;

        public PointOfIntrestsController(Homework_TripsContext context)
        {
            _context = context;
        }

        // GET: PointOfIntrests
        public async Task<IActionResult> Index()
        {
            return View(await _context.PointOfIntrest.ToListAsync());
        }

        // GET: PointOfIntrests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfIntrest = await _context.PointOfIntrest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfIntrest == null)
            {
                return NotFound();
            }

            return View(pointOfIntrest);
        }

        // GET: PointOfIntrests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PointOfIntrests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PointOfIntrest pointOfIntrest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointOfIntrest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pointOfIntrest);
        }

        // GET: PointOfIntrests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfIntrest = await _context.PointOfIntrest.FindAsync(id);
            if (pointOfIntrest == null)
            {
                return NotFound();
            }
            return View(pointOfIntrest);
        }

        // POST: PointOfIntrests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] PointOfIntrest pointOfIntrest)
        {
            if (id != pointOfIntrest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointOfIntrest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointOfIntrestExists(pointOfIntrest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pointOfIntrest);
        }

        // GET: PointOfIntrests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfIntrest = await _context.PointOfIntrest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfIntrest == null)
            {
                return NotFound();
            }

            return View(pointOfIntrest);
        }

        // POST: PointOfIntrests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointOfIntrest = await _context.PointOfIntrest.FindAsync(id);
            if (pointOfIntrest != null)
            {
                _context.PointOfIntrest.Remove(pointOfIntrest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointOfIntrestExists(int id)
        {
            return _context.PointOfIntrest.Any(e => e.Id == id);
        }
    }
}
