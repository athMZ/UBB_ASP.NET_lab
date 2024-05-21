using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
	public class CustomerRepository : ARepository<Customer, string>
	{
		public CustomerRepository(TripContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public override IQueryable<Customer> GetAll()
		{
			return Context.Customers
				.AsNoTracking()
				.Include(customer => customer.Reservations);
		}

		public override Customer? GetById(string id)
		{
			var result = Context.Customers
				.AsNoTracking()
				.Include(customer => customer.Reservations)
				.FirstOrDefault(customer => customer.Id == id);

			return result;
		}

		public override void Insert(Customer entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			if (Context.Customers.Any(c => c.Id == entity.Id))
				throw new InvalidOperationException("Customer with the same ID already exists.");

			Context.Customers.Add(entity);
		}

		public override void Update(Customer entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			var customer = GetById(entity.Id);
			if (customer == null)
				throw new InvalidOperationException("City not found.");

			Context.Customers.Update(customer);

			customer.FirstName = entity.FirstName;
			customer.LastName = entity.LastName;
			customer.Email = entity.Email;
		}

		public override void Delete(string id)
		{
			var customer = GetById(id);

			if (customer == null)
				throw new InvalidOperationException("City not found.");

			Context.Customers.Remove(customer);
		}

		public override void Delete(Customer entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			Delete(entity.Id);
		}

		public override bool Exists(string id) => Context.Customers.Any(c => c.Id == id);

		public override bool Exists(Customer entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			return Exists(entity.Id);
		}
	}
}
