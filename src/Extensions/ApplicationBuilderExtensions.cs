using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Avolutions.Baf.Blazor.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseBafBlazor<TApp>(this WebApplication app)
    {
        app.MapRazorComponents<TApp>()
            .AddInteractiveServerRenderMode();

        return app;
    }
}