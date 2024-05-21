using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface ICustomerService
{
	IEnumerable<CustomerDto> GetAll();
	CustomerDto GetById(string id);

	bool Exists(string id);
	void Delete(string id);

	void Insert(CustomerDto entity);
	void Update(CustomerDto entity);

	bool EmailExists(string email);
}