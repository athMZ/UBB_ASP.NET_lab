using AutoMapper;
using Serilog;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;

namespace Trips.DAL.Services
{
	public class CountryService : ICountryService
	{
		private readonly IRepository<Country> _countryRepository;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public CountryService(IRepository<Country> countryRepository, ILogger logger, IMapper mapper)
		{
			_countryRepository = countryRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<CountryDto> GetAllDto()
		{
			var cities = _countryRepository.GetAll();
			var result = _mapper.Map<IEnumerable<CountryDto>>(cities);

			return result;
		}

		public CountryDto GetByIdDto(int id)
		{
			var city = _countryRepository.GetById(id);
			var result = _mapper.Map<CountryDto>(city);
			return result;
		}

		public void InsertCountry(CountryDto countryDto)
		{
			var country = _mapper.Map<Country>(countryDto);

			_countryRepository.Insert(country);
			_countryRepository.Save();
		}

		public void UpdateCountry(CountryDto countryDto)
		{
			var country = _mapper.Map<Country>(countryDto);

			_countryRepository.Update(country);
			_countryRepository.Save();
		}

		public void Delete(int id)
		{
			_countryRepository.Delete(id);
			_countryRepository.Save();
		}

		public bool Exists(int id)
		{
			return _countryRepository.Exists(id);
		}
	}
}
