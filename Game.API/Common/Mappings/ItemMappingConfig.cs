using Game.Contracts.Item;
using Game.Domain.Entities;
using Mapster;

namespace Game.API.Common.Mappings;

public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ItemRequest, Item>().Ignore("Id");
    }
}
