using Game.Infrastructure.IRepositories;

namespace Game.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfwork
{
    private readonly GameContext _contexet;

    public IItemRepository Items { get; private set; }

    public UnitOfWork(GameContext contexet)
    {
        _contexet = contexet;
        Items = new ItemRepository(_contexet);
    }

    public async Task SaveAsync()
    {
        await _contexet.SaveChangesAsync();
    }

    public void Dispose()
    {
        _contexet.Dispose();
    }
}
