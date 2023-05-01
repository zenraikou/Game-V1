namespace Game.Infrastructure.IRepositories;

public interface IUnitOfwork : IDisposable
{
    IItemRepository Items { get; }
    Task SaveAsync();
}
