using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using ILogger = Serilog.ILogger;

namespace Trips.DAL.Services
{
	public class CityService : ICityService
	{
		private readonly IRepository<City, int> _cityRepository;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public CityService(IRepository<City, int> cityRepository, ILogger logger, IMapper mapper)
		{
			_cityRepository = cityRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<CityDto> GetAll()
		{
			var cities = _cityRepository.GetAll();
			var result = _mapper.Map<IEnumerable<CityDto>>(cities);
			return result;
		}

		public CityDto GetById(int id)
		{
			var city = _cityRepository.GetById(id);
			var result = _mapper.Map<CityDto>(city);
			return result;
		}

		public void Delete(int id)
		{
			_cityRepository.Delete(id);
			_cityRepository.Save();
		}

		public void Insert(CityDto entity)
		{
			var city = _mapper.Map<City>(entity);

			_cityRepository.Insert(city);
			_cityRepository.Save();
		}

		public void Update(CityDto entity)
		{
			var city = _mapper.Map<City>(entity);

			_cityRepository.Update(city);
			_cityRepository.Save();
		}

		public bool Exists(int id)
		{
			return _cityRepository.Exists(id);
		}
	}
}
