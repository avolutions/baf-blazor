using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
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