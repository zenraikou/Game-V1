using Game.Core.Common.Interfaces.Persistence;
using Game.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<GameDBContext>(options => options.UseSqlServer(config.GetConnectionString("GameConnection")));
        services.AddScoped<IUnitOfwork, UnitOfWork>();
        return services;
    }
}
