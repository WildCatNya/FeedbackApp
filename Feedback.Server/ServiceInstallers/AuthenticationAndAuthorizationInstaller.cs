using Feedback.Server.Helpers;
using Feedback.Server.ServiceInstallers.Abstraction;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

namespace Feedback.Server.ServiceInstallers;

public sealed class AuthenticationAndAuthorizationInstaller : ServiceInstaller
{
    public override void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

        services.AddAuthorization();

        services.AddHttpContextAccessor();

        services.AddScoped<AuthenticationStateProvider, RevalidatingFeedbackAuthenticationStateProvider>();
    }
}