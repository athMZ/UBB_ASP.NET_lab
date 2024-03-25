using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface IPointOfIntrestService
{
	IEnumerable<PointOfIntrestDto> GetAllDto();
	PointOfIntrestDto GetByIdDto(int id);

	bool Exists(int id);
	void Delete(int id);
	void InsertPointOfInterest(PointOfIntrestDto pointOfInterestDto);
	void UpdatePointOfInterest(PointOfIntrestDto pointOfInterestDto);
}