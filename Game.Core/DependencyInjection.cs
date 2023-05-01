using System.Reflection;
using FluentValidation;
using Game.Core.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection service)
    {
        service.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        service.AddMediatR(Assembly.GetExecutingAssembly());
        
        return service;
    }
}
