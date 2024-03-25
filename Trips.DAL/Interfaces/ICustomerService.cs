using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces
{
	public interface ICustomerService
	{
		IEnumerable<CustomerDto> GetAllDto();
		CustomerDto GetByIdDto(int id);

		bool Exists(int id);
		void Delete(int id);
		void InsertCustomer(CustomerDto customerDto);
		void UpdateCustomer(CustomerDto customerDto);
	}
}
