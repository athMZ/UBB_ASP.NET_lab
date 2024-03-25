using AutoMapper;
using Serilog;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;

namespace Trips.DAL.Services
{
	public class PointOfIntrestService : IPointOfIntrestService
	{
		private readonly IRepository<PointOfIntrest> _pointOfInterestRepository;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public PointOfIntrestService(IRepository<PointOfIntrest> pointOfInterestRepository, ILogger logger, IMapper mapper)
		{
			_pointOfInterestRepository = pointOfInterestRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<PointOfIntrestDto> GetAllDto()
		{
			var pointsOfIntrest = _pointOfInterestRepository.GetAll();
			var result = _mapper.Map<IEnumerable<PointOfIntrestDto>>(pointsOfIntrest);
			return result;
		}

		public PointOfIntrestDto GetByIdDto(int id)
		{
			var pointOfIntrest = _pointOfInterestRepository.GetById(id);
			var result = _mapper.Map<PointOfIntrestDto>(pointOfIntrest);
			return result;
		}

		public bool Exists(int id)
		{
			return _pointOfInterestRepository.Exists(id);
		}

		public void Delete(int id)
		{
			_pointOfInterestRepository.Delete(id);
			_pointOfInterestRepository.Save();
		}

		public void InsertPointOfInterest(PointOfIntrestDto pointOfInterestDto)
		{
			var pointOfIntrest = _mapper.Map<PointOfIntrest>(pointOfInterestDto);

			_pointOfInterestRepository.Insert(pointOfIntrest);
			_pointOfInterestRepository.Save();
		}

		public void UpdatePointOfInterest(PointOfIntrestDto pointOfInterestDto)
		{
			var pointOfIntrest = _mapper.Map<PointOfIntrest>(pointOfInterestDto);

			_pointOfInterestRepository.Update(pointOfIntrest);
			_pointOfInterestRepository.Save();
		}
	}
}
