namespace Game.Core.Common.Interfaces.Persistence;

public interface IUnitOfwork : IDisposable
{
    IItemRepository Items { get; }
    Task SaveAsync();
}
