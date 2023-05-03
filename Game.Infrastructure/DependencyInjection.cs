using Game.Core.Common.Interfaces.Persistence;
using Game.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        var configurations = service.BuildServiceProvider().GetRequiredService<IConfiguration>();
        service.AddDbContext<GameDBContext>(options => options.UseSqlServer(configurations.GetConnectionString("GameConnection")));
        service.AddScoped<IUnitOfwork, UnitOfWork>();
        return service;
    }
}
