using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Avolutions.Baf.Blazor.Account.Extensions;

public static class IdentityExtensions
{
    private static Guid? GetUserId(this ClaimsPrincipal user)
    {
        return Guid.TryParse(user.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : null;
    }

    public static async Task<Guid?> GetUserIdAsync(this AuthenticationStateProvider auth)
    {
        return (await auth.GetAuthenticationStateAsync()).User.GetUserId();
    }
}