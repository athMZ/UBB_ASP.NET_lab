namespace Trips.DAL.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
	IEnumerable<TEntity> GetAll();
	TEntity? GetById(int id);

	void Insert(TEntity entity);
	void Update(TEntity entity);

	void Delete(int id);
	void Delete(TEntity entity);

	bool Exists(int id);
	bool Exists(TEntity entity);

	void Save();
}