using Avolutions.Baf.Blazor.Entity.Abstractions;
using Avolutions.Baf.Blazor.Entity.Services;
using Avolutions.Baf.Core.Entity.Abstractions;
using Avolutions.Baf.Core.Entity.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Entity;

public class EntityModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped(typeof(IEntityService<>), typeof(BlazorEntityService<>));
        services.AddScoped(typeof(IBlazorEntityService<>), typeof(BlazorEntityService<>));
    }
}