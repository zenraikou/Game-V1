using System.Linq.Expressions;

namespace Game.Core.Common.Interfaces.Persistence;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? expression = null);
    Task PostAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
