using Game.Contracts.User;
using Game.Domain.Entities;
using Mapster;

namespace Game.API.Common.Mappings;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserRequest, User>().Ignore("Id");
        config.NewConfig<UserRequest, User>().Map(dest => dest.PasswordHash, src => src.Password);
    }
}
