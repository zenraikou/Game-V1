using Game.Core.Common.Interfaces.Persistence;

namespace Game.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfwork
{
    private readonly GameDBContext _context;

    public IItemRepository Items { get; private set; }

    public UnitOfWork(GameDBContext context)
    {
        _context = context;
        Items = new ItemRepository(context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
