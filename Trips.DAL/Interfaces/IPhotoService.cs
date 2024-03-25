using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces
{
	public interface IPhotoService
	{
		IEnumerable<PhotoDto> GetAllDto();
		PhotoDto GetByIdDto(int id);

		bool Exists(int id);
		void Delete(int id);
		void InsertCustomer(PhotoDto photoDto);
		void UpdateCustomer(PhotoDto photoDto);
	}
}
