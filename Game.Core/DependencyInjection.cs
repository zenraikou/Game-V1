using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection));
        return services;
    }
}
