using System.Linq.Expressions;
using Game.Core.Common.Interfaces.Persistence;
using Game.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Persistence;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly GameDBContext _context;
    private readonly DbSet<TEntity> _db;

    public GenericRepository(GameDBContext context)
    {
        _context = context;
        _db = _context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression)
    {
        IQueryable<TEntity> query = _db;
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? expression)
    {
        IQueryable<TEntity> query = _db;

        if (expression is not null)
        {
            query = query.Where(expression);
        }
        
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task PostAsync(TEntity entity)
    {
        await _db.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _db.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _db.Remove(entity);
    }
}
