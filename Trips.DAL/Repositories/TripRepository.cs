using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
	public class TripRepository : ARepository<Trip>
	{
		public TripRepository(TripContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public override IQueryable<Trip> GetAll()
		{
			return Context.Trips
				.AsNoTracking()
				.Include(trip => trip.Photo)
				.Include(trip => trip.Reservations)
				.Include(trip => trip.PointsOfIntrest);
		}

		public override Trip? GetById(int id)
		{
			return Context.Trips
				.AsNoTracking()
				.Include(trip => trip.Photo)
				.Include(trip => trip.Reservations)
				.Include(trip => trip.PointsOfIntrest)
				.FirstOrDefault(trip => trip.Id == id);
		}

		public override void Insert(Trip entity)
		{
			throw new NotImplementedException();

/*			ArgumentNullException.ThrowIfNull(entity);

			if (Context.Trips.Any(c => c.Id == entity.Id))
				throw new InvalidOperationException("Trip with the same ID already exists.");

			var photo = Context.Photos.SingleOrDefault(c => c.Id == entity.PhotoId);
			if (photo == null)
				throw new InvalidOperationException("Photo not found.");

			var reservations = Context.Reservations.Where(c => entity.ReservationsIds != null && entity.ReservationsIds.Contains(c.Id));
			if ( reservations == null)
				throw new InvalidOperationException("Reservations not found.");

			var pointsOfInterest = Context.PointsOfIntrest.Where(c => entity.PointsOfIntrestIds != null && entity.PointsOfIntrestIds.Contains(c.Id));
			if (pointsOfInterest == null)
				throw new InvalidOperationException("Points of interesr not found.");

			entity.PhotoId = photo.Id;
			entity.ReservationsIds = reservations.Select(r => r.Id).ToList();
			entity.PointsOfIntrestIds = pointsOfInterest.Select(r => r.Id).ToList();

			Context.Trips.Add(entity);*/
		}

		public override void Update(Trip entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			var trip = GetById(entity.Id);
			if (trip == null)
				throw new InvalidOperationException("City not found.");

/*			trip.ReservationsIds = entity.ReservationsIds;
			trip.PointsOfIntrestIds = entity.PointsOfIntrestIds;*/
			trip.PhotoId = entity.PhotoId;
			trip.Description = entity.Description;
			trip.Name = entity.Name;
			trip.Price = entity.Price;
			trip.StartDate = entity.StartDate;
			trip.EndDate = entity.EndDate;
		}

		public override void Delete(int id)
		{
			var trip = GetById(id);

			if (trip == null)
				throw new InvalidOperationException("Trip not found.");

			Context.Trips.Remove(trip);
		}

		public override void Delete(Trip entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			Delete(entity.Id);		}

		public override bool Exists(int id) => Context.Trips.Any(c => c.Id == id);


		public override bool Exists(Trip entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			return Exists(entity.Id);
		}
	}
}
