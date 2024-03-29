﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework_Trips.Data;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using Trips.DAL.Services;

namespace Homework_Trips.Controllers
{
	public class PhotosController : Controller
	{
		private readonly IPhotoService _photoService;

		public PhotosController(IPhotoService photoService)
		{
			_photoService = photoService;
		}

		// GET: Photos
		public async Task<IActionResult> Index()
		{
			var result = _photoService.GetAllDto();
			return View(result);
		}

		// GET: Photos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return NotFound();

			var photo = _photoService.GetByIdDto(id.Value);
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
			if (!ModelState.IsValid) return View(photoDto);

			_photoService.InsertCustomer(photoDto);
			return RedirectToAction(nameof(Index));
		}

		// GET: Photos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _photoService.GetByIdDto(id.Value);

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

			if (!ModelState.IsValid) return View(photoDto);

			try
			{
				_photoService.UpdateCustomer(photoDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PhotoExists(photoDto.Id))
				{
					return NotFound();
				}

				throw;
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: Photos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var result = _photoService.GetByIdDto(id.Value);

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
