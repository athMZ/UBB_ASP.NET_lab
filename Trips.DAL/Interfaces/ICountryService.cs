using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface ICountryService
{
	IEnumerable<CountryDto> GetAllDto();
	CountryDto GetByIdDto(int cityDtoCountryId);
	void InsertCountry(CountryDto countryDto);
	void UpdateCountry(CountryDto countryDto);
	void Delete(int id);
	bool Exists(int id);
}