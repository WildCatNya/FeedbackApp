using Feedback.Server.Database.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Feedback.Server.Extensions;

public static class DefaultExtension
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source) action.Invoke(item);
    }

    public static ClaimsPrincipal GetClaimsPrincipal(this UserAccount? userAccount)
    {
        List<Claim> claims =
        [
            new(ClaimTypes.Name, userAccount.Login),
            new(ClaimTypes.NameIdentifier, userAccount.Id.ToString()),
            new(ClaimTypes.Expiration, DateTime.Now.ToLocalTime().AddHours(12).ToString())
        ];

        userAccount.UserAccountRoles.Select(x => x.Role?.Name)
            .ForEach(x => claims.Add(new(ClaimTypes.Role, x)));

        ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new(claimsIdentity);
    }
}