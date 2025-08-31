using Avolutions.Baf.Blazor.Setup.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace Avolutions.Baf.Blazor.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseBafBlazor<TApp>(this WebApplication app)
    {
        app.UseMiddleware<SetupRedirectMiddleware>();
        
        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<TApp>()
            .AddInteractiveServerRenderMode()
            .AddAdditionalAssemblies(typeof(AssemblyMarker).Assembly);

        return app;
    }
}