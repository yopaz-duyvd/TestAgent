namespace Hackathon.Extensions;

using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static long? GetUserId(this ClaimsPrincipal user)
    {
        if (user.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        var claim = user.FindFirst("userId");
        return claim != null && long.TryParse(claim.Value, out var userId)
            ? userId
            : null;
    }

    public static string? GetUserRole(this ClaimsPrincipal user)
    {
        if (user.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        return user.FindFirst("role")?.Value;
    }
}

