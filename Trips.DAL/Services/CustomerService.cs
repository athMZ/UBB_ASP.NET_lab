using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;
using ILogger = Serilog.ILogger;

namespace Trips.DAL.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer, string> _customerRepository;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public CustomerService(IRepository<Customer, string> customerRepository, ILogger logger, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<CustomerDto> GetAll()
		{
			var customers = _customerRepository.GetAll();
			var result = _mapper.Map<IEnumerable<CustomerDto>>(customers);
			return result;
		}

		public CustomerDto GetById(string id)
		{
			var customer = _customerRepository.GetById(id);
			var result = _mapper.Map<CustomerDto>(customer);
			return result;
		}

		public bool Exists(string id)
		{
			return _customerRepository.Exists(id);
		}

		public void Delete(string id)
		{
			_customerRepository.Delete(id);
			_customerRepository.Save();
		}

		public void Insert(CustomerDto customerDto)
		{
			var customer = _mapper.Map<Customer>(customerDto);

			_customerRepository.Insert(customer);
			_customerRepository.Save();
		}

		public void Update(CustomerDto customerDto)
		{
			var customer = _mapper.Map<Customer>(customerDto);

			_customerRepository.Update(customer);
			_customerRepository.Save();
		}

		public bool EmailExists(string email)
		{
			var result = _customerRepository.GetAll().Any(x => x.Email == email);
			return result;
		}
	}
}
