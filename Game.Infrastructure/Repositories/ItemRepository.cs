using Game.Domain.Entities;
using Game.Infrastructure.IRepositories;

namespace Game.Infrastructure.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository 
{ 
    public ItemRepository(GameContext context) : base(context) { }
}
