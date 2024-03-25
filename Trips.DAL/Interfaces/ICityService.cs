using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface ICityService
{
	IEnumerable<CityDto> GetAllDto();
	CityDto GetByIdDto(int id);

	bool Exists(int id);
	void Delete(int id);
	void InsertCity(CityDto cityDto, CountryDto countryDto);
	void UpdateCity(CityDto cityDto, CountryDto countryDto);
}