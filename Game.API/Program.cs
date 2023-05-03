using Game.API;
using Game.Core;
using Game.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAPI(builder.Host);
    builder.Services.AddCore();
    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseAPI();
    app.Run();
}
