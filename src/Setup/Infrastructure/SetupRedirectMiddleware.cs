using Avolutions.Baf.Core.Setup.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Avolutions.Baf.Blazor.Setup.Infrastructure;

public class SetupRedirectMiddleware
{
    private readonly RequestDelegate _next;
    
    public SetupRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext ctx, SetupState state)
    {
        var path = (ctx.Request.Path.Value ?? string.Empty).ToLowerInvariant();

        if (!state.IsCompleted)
        {
            // Allow the setup UI and essential static assets to load
            var allowed = path.StartsWith("/setup")
                          || path.StartsWith("/_content")
                          || path.StartsWith("/_framework")
                          || path.StartsWith("/_blazor")
                          || path.StartsWith("/css")
                          || path.StartsWith("/js")
                          || path.StartsWith("/images")
                          || path == "/favicon.ico";
            if (!allowed)
            {
                ctx.Response.Redirect("/setup");
                return;
            }
        }
        else
        {
            // After setup: block direct access to /setup
            if (path.StartsWith("/setup"))
            {
                ctx.Response.Redirect("/");
                return;
            }
        }

        await _next(ctx);
    }
}
