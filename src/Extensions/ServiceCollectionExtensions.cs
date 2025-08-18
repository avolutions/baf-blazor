using System.Reflection;
using Avolutions.BAF.Core.Module.Abstractions;
using Avolutions.BAF.Core.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;

namespace Avolutions.Baf.Blazor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBafBlazor(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMudServices();
        
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        return services;
    }
}