using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
	public class CityRepository : ARepository<City>
	{
		public CityRepository(TripContext context) : base(context) { }

		public override IEnumerable<City> GetAll() => Context.Cities;

		public override City? GetById(int id)
		{
			var cityWithCountry = Context.Cities
				.Include(city => city.Country)
				.FirstOrDefault(city => city.Id == id);

			return cityWithCountry;
		}

		public override void Insert(City entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			if (Context.Cities.Any(c => c.Id == entity.Id))
				throw new InvalidOperationException("City with the same ID already exists.");

			Context.Cities.Add(entity);
		}

		public override void Update(City entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			var city = GetById(entity.Id);
			if (city == null)
				throw new InvalidOperationException("City not found.");

			Context.Entry(city).CurrentValues.SetValues(entity);
		}

		public override void Delete(int id)
		{
			var city = GetById(id);

			if (city == null)
				throw new InvalidOperationException("City not found.");

			Context.Cities.Remove(city);
		}

		public override void Delete(City entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			Delete(entity.Id);
		}

		public override bool Exists(int id) => Context.Cities.Any(c => c.Id == id);

		public override bool Exists(City entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			return Exists(entity.Id);
		}
	}
}
