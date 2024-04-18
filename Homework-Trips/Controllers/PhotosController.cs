using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.DTOs;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Homework_Trips.Controllers
{
	public class PhotosController : Controller
	{
		private readonly IPhotoService _photoService;
		private readonly IValidator<PhotoDto> _photoValidator;

		public PhotosController(IPhotoService photoService, IValidator<PhotoDto> photoValidator)
		{
			_photoService = photoService;
			_photoValidator = photoValidator;
		}

		// GET: Photos
		public async Task<IActionResult> Index()
		{
			var result = _photoService.GetAll();
			return View(result);
		}

		// GET: Photos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return NotFound();

			var photo = _photoService.GetById(id.Value);
			return View(photo);
		}

		// GET: Photos/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Photos/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,FileName,AltText")] PhotoDto photoDto)
		{
			var result = await _photoValidator.ValidateAsync(photoDto);

			if (!ModelState.IsValid || !result.IsValid)
			{
				result.AddToModelState(ModelState);
				return View(photoDto);
			}

			_photoService.Insert(photoDto);
			return RedirectToAction(nameof(Index));
		}

		// GET: Photos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _photoService.GetById(id.Value);

			return View(result);
		}

		// POST: Photos/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,FileName,AltText")] PhotoDto photoDto)
		{
			if (id != photoDto.Id)
				return NotFound();

			var result = await _photoValidator.ValidateAsync(photoDto);

			if (!ModelState.IsValid || !result.IsValid)
			{
				result.AddToModelState(ModelState);
				return View(photoDto);
			}

			try
			{
				_photoService.Update(photoDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PhotoExists(photoDto.Id))
					return NotFound();

				throw;
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: Photos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _photoService.GetById(id.Value);

			return View(result);
		}

		// POST: Photos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			_photoService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

		private bool PhotoExists(int id)
		{
			return _photoService.Exists(id);
		}

	}
}
