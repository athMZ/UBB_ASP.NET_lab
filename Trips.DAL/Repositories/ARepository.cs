using AutoMapper;
using Trips.DAL.Data;
using Trips.DAL.Interfaces;

namespace Trips.DAL.Repositories
{
	public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly TripContext Context;
		protected readonly IMapper Mapper;

		private protected ARepository(TripContext context, IMapper mapper)
		{
			Context = context;
			Mapper = mapper;
		}

		public abstract IEnumerable<TEntity> GetAll();

		public abstract TEntity? GetById(int id);

		public abstract void Insert(TEntity entity);

		public abstract void Update(TEntity entity);

		public abstract void Delete(int id);

		public abstract void Delete(TEntity entity);

		public abstract bool Exists(int id);

		public abstract bool Exists(TEntity entity);

		public void Save() => Context.SaveChanges();

		private bool _disposed;
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing) Context.Dispose();
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
