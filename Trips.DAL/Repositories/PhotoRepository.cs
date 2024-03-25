using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
	public class PhotoRepository : ARepository<Photo>
	{
		public PhotoRepository(TripContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public override IEnumerable<Photo> GetAll()
		{
			return Context.Photos
				.AsNoTracking();
		}

		public override Photo? GetById(int id)
		{
			return Context.Photos
				.AsNoTracking()
				.FirstOrDefault(photo => photo.Id == id);
		}

		public override void Insert(Photo entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			if (Context.Photos.Any(c => c.Id == entity.Id))
				throw new InvalidOperationException("Photo with the same ID already exists.");

			Context.Photos.Add(entity);
		}

		public override void Update(Photo entity)
		{
			ArgumentNullException.ThrowIfNull(entity);

			var photo = GetById(entity.Id);
			if (photo == null)
				throw new InvalidOperationException("City not found.");

			Context.Photos.Update(photo);

			photo.Title = entity.Title;
			photo.AltText = entity.AltText;
			photo.FileName = entity.FileName;
		}

		public override void Delete(int id)
		{
			var photo = GetById(id);

			if (photo == null)
				throw new InvalidOperationException("City not found.");

			Context.Photos.Remove(photo);		}

		public override void Delete(Photo entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			Delete(entity.Id);
		}

		public override bool Exists(int id) => Context.Photos.Any(c => c.Id == id);

		public override bool Exists(Photo entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			return Exists(entity.Id);
		}
	}
}
