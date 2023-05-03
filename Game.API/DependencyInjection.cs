using Game.API.Common.Mappings;

namespace Game.API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        services.AddMappings();
        return services;
    }
}
