namespace Game.Core.Common.Interfaces.Persistence;

public interface IUnitOfwork : IDisposable
{
    IAccountRepository Accounts { get; }
    IItemRepository Items { get; }
    Task SaveAsync();
}
