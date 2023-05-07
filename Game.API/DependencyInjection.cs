using FluentValidation;
using Game.API.Common.Interfaces;
using Game.API.Common.Mappings;
using Serilog;

namespace Game.API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services, IHostBuilder host)
    {
        services.AddControllers();
        services.AddMvc().AddNewtonsoftJson();
        services.AddRouting(options => options.LowercaseUrls = true);
        host.UseSerilog((conext, config) => config.ReadFrom.Configuration(conext.Configuration));
        services.AddLogging(loggingBuilder => loggingBuilder.ClearProviders().AddSerilog(dispose: true));
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        services.AddMappings();
        return services;
    }

    public static IApplicationBuilder UseAPI(this IApplicationBuilder app)
    {
        app.UseExceptionHandler("/api/error");
        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
        return app;
    }
}
