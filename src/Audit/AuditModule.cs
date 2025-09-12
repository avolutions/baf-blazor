using Avolutions.Baf.Blazor.Audit.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Audit;

public class AuditModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<AuditInfoDialogService>();
    }
}