using Avolutions.Baf.Blazor.Jobs.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Jobs;

public class JobsModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<ExecuteJobDialogService>();
    }
}