using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
	public class CountryRepository : ARepository<Country>
	{
		public CountryRepository(TripContext context, IMapper mapper) : base(context, mapper) { }

		public override IQueryable<Country> GetAll()
		{
			return Context.Countries
				.AsNoTracking();
		}

		public override Country? GetById(int id)
		{
			return Context.Countries
				.AsNoTracking()
				.FirstOrDefault(c => c.Id == id);
		}

		public override void Insert(Country entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			if (Context.Countries.Any(c => c.Id == entity.Id))
				throw new InvalidOperationException("Country with the same ID already exists.");

			Context.Countries.Add(entity);
		}

		public override void Update(Country entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			var country = GetById(entity.Id);
			if (country == null)
				throw new InvalidOperationException("Country not found.");

			Context.Countries.Update(country);

			country.Name = entity.Name;
		}

		public override void Delete(int id)
		{
			var country = GetById(id);

			if (country == null)
				throw new InvalidOperationException("Country not found.");

			Context.Countries.Remove(country);
		}

		public override void Delete(Country entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			Delete(entity.Id);
		}

		public override bool Exists(int id) => Context.Countries.Any(c => c.Id == id);

		public override bool Exists(Country entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			return Exists(entity.Id);
		}
	}
}
