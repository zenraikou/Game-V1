using Game.API;
using Game.Core;
using Game.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddMvc().AddNewtonsoftJson();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Host.UseSerilog((contxet, configuration) => configuration.ReadFrom.Configuration(contxet.Configuration));
    builder.Services.AddAPI();
    builder.Services.AddCore();
    builder.Services.AddInfrastructure();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/api/error");
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
