using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Avolutions.Baf.Blazor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBafBlazor(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddValidatorsFromAssembly(typeof(AssemblyMarker).Assembly);
        
        services.AddMudServices();
        
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        return services;
    }
}