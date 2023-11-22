using Feedback.Server.Helpers;
using Feedback.Server.ServiceInstallers.Abstraction;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Feedback.Server.ServiceInstallers;

public sealed class AuthenticationAndAuthorizationInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

        services.AddAuthorization();

        services.AddHttpContextAccessor();

        services.AddSingleton<AuthHelper>();
    }
}