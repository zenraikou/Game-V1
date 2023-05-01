using Game.Infrastructure.IRepositories;
using Game.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IUnitOfwork, UnitOfWork>();
        service.AddDbContext<GameContext>(options => 
        {
            options.UseSqlServer(
                configuration.GetConnectionString("GameConnection"),
                b => b.MigrationsAssembly("Game.Infrastructure"));
        });

        return service;
    }
}
