namespace Trips.DAL.Interfaces;

public interface IService<TEntity> where TEntity : class
{
	IEnumerable<TEntity> GetAll();
	TEntity GetById(int id);

	bool Exists(int id);
	void Delete(int id);

	void Insert(TEntity entity);
	void Update(TEntity entity);
}