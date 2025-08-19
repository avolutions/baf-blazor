using Avolutions.Baf.Blazor.Forms.Services;
using Avolutions.BAF.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Forms;

public class FormsModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<ConfirmLeaveDialogService>();
    }
}