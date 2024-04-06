using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
	public class PointOfInterestRepository : ARepository<PointOfIntrest>
	{
		public PointOfInterestRepository(TripContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public override IQueryable<PointOfIntrest> GetAll()
		{
			return Context.PointsOfIntrest
				.AsNoTracking()
                .Include(poi => poi.City)
                .Include(poi=>poi.Photo);
		}

		public override PointOfIntrest? GetById(int id)
        {
            return Context.PointsOfIntrest
                .AsNoTracking()
                .Include(poi => poi.City)
                .Include(poi => poi.Photo)
                .FirstOrDefault(pointOfIntrest => pointOfIntrest.Id == id);
        }

		public override void Insert(PointOfIntrest entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			if (Context.PointsOfIntrest.Any(p => p.Id == entity.Id))
				throw new InvalidOperationException("Point of interest with the same ID already exists.");

			Context.PointsOfIntrest.Add(entity);
		}

		public override void Update(PointOfIntrest entity)
		{
			var pointOfInterest = GetById(entity.Id);
			if (pointOfInterest == null)
				throw new InvalidOperationException("Point of interest not found.");

			Context.PointsOfIntrest.Update(pointOfInterest);

			pointOfInterest.Name = entity.Name;
			pointOfInterest.Description = entity.Description;
			pointOfInterest.CityId = entity.CityId;
			pointOfInterest.PhotoId = entity.PhotoId;
		}

		public override void Delete(int id)
		{
			var pointOfIntrest = GetById(id);

			if (pointOfIntrest == null)
				throw new InvalidOperationException("City not found.");

			Context.PointsOfIntrest.Remove(pointOfIntrest);
		}

		public override void Delete(PointOfIntrest entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			Delete(entity.Id);
		}

		public override bool Exists(int id) => Context.PointsOfIntrest.Any(c => c.Id == id);


		public override bool Exists(PointOfIntrest entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			return Exists(entity.Id);
		}
	}
}
