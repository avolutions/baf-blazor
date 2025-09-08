using Avolutions.Baf.Blazor.Account.Services;
using Avolutions.Baf.Core.Module.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Account;

public class AccountModule : IFeatureModule
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<AccountDialogService>();
    }
}