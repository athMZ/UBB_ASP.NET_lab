using AutoMapper;
using Serilog;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;

namespace Trips.DAL.Services
{
	public class CountryService : ICountryService
	{
		private readonly IRepository<Country, int> _countryRepository;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public CountryService(IRepository<Country, int> countryRepository, ILogger logger, IMapper mapper)
		{
			_countryRepository = countryRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<CountryDto> GetAll()
		{
			var cities = _countryRepository.GetAll();
			var result = _mapper.Map<IEnumerable<CountryDto>>(cities);

			return result;
		}

		public CountryDto GetById(int id)
		{
			var city = _countryRepository.GetById(id);
			var result = _mapper.Map<CountryDto>(city);
			return result;
		}

		public void Insert(CountryDto entity)
		{
			var country = _mapper.Map<Country>(entity);

			_countryRepository.Insert(country);
			_countryRepository.Save();
		}

		public void Update(CountryDto entity)
		{
			var country = _mapper.Map<Country>(entity);

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

		public IEnumerable<CountryDto> GetAllAlphabetical()
		{
			var countries = _countryRepository
				.GetAll()
				.OrderBy(c => c.Name);

			var result = _mapper.Map<IEnumerable<CountryDto>>(countries);
			return result;
		}
	}
}
