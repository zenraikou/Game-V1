using Game.Contracts.Items;
using Game.Domain.Entities;
using Mapster;

namespace Game.API.Common.Mappings;

public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ItemRequest, Item>().Ignore("Id");
        // config.ForType<ItemRequest, Item>().Map(dest => dest.Id, src => src.Id);
    }
}
