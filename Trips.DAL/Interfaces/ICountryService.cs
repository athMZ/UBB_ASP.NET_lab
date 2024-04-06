using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface ICountryService : IService<CountryDto>
{
	public IEnumerable<CountryDto> GetAllAlphabetical();

}