using Avolutions.Baf.Blazor.Dialogs.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Dialogs;

public class DialogsModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<DeleteDialogService>();
    }
}