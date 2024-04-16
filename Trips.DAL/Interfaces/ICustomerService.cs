using Trips.DAL.DTOs;

namespace Trips.DAL.Interfaces;

public interface ICustomerService : IService<CustomerDto>
{
	bool EmailExists(string email);
}