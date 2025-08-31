using Avolutions.Baf.Blazor.Snackbar.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Snackbar;

public class SnackbarModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<SnackbarNotificationService>();
    }
}