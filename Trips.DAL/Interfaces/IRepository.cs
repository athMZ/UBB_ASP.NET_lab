namespace Trips.DAL.Interfaces;

public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
{
	IQueryable<TEntity> GetAll();
	TEntity? GetById(TKey id);

	void Insert(TEntity entity);
	void Update(TEntity entity);

	void Delete(TKey id);
	void Delete(TEntity entity);

	bool Exists(TKey id);
	bool Exists(TEntity entity);

	void Save();
}