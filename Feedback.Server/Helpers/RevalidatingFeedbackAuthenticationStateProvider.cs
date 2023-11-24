using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using System.Security.Claims;

namespace Feedback.Server.Helpers;

public class RevalidatingFeedbackAuthenticationStateProvider(ILoggerFactory loggerFactory)
        : RevalidatingServerAuthenticationStateProvider(loggerFactory)
{
    protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(10);

    protected override Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
    {
        IEnumerable<Claim> userClaims = authenticationState.User.Claims;

        Claim? claim = userClaims.FirstOrDefault(x => x.Type.Contains("expiration"));

        if (claim is null)
            return Task.FromResult(false);

        DateTime expirationDateTime = DateTime.Parse(claim.Value);

        bool isValid = DateTime.Now.ToLocalTime() < expirationDateTime;

        return Task.FromResult(isValid);
    }
}