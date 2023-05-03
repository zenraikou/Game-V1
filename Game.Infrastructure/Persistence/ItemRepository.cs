using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;

namespace Game.Infrastructure.Persistence;

public class ItemRepository : GenericRepository<Item>, IItemRepository 
{ 
    public ItemRepository(GameDBContext context) : base(context) { }
}
