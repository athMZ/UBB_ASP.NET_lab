﻿using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using ILogger = Serilog.ILogger;

namespace Trips.DAL.Services
{
	public class PhotoService : IPhotoService
	{
		private readonly IRepository<Photo> _photoRepository;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public PhotoService(IRepository<Photo> photoRepository, ILogger logger, IMapper mapper)
		{
			_photoRepository = photoRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<PhotoDto> GetAllDto()
		{
			var photos = _photoRepository.GetAll();
			var result = _mapper.Map<IEnumerable<PhotoDto>>(photos);
			return result;
		}

		public PhotoDto GetByIdDto(int id)
		{
			var photo = _photoRepository.GetById(id);
			var result = _mapper.Map<PhotoDto>(photo);
			return result;
		}

		public bool Exists(int id)
		{
			return _photoRepository.Exists(id);
		}

		public void Delete(int id)
		{
			_photoRepository.Delete(id);
			_photoRepository.Save();
		}

		public void InsertCustomer(PhotoDto photoDto)
		{
			var photo = _mapper.Map<Photo>(photoDto);

			_photoRepository.Insert(photo);
			_photoRepository.Save();
		}

		public void UpdateCustomer(PhotoDto photoDto)
		{
			var photo = _mapper.Map<Photo>(photoDto);

			_photoRepository.Update(photo);
			_photoRepository.Save();
		}
	}
}
