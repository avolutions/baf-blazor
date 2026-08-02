using Avolutions.Baf.Blazor.LockStatus.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.LockStatus;

public class LockStatusModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<LockStatusDialogService>();
    }
}