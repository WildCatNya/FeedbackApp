using Feedback.Server.ServiceInstallers.Abstraction;
using Feedback.Server.Services;
using Feedback.Server.Services.Abstractions;

namespace Feedback.Server.ServiceInstallers;

public sealed class SnackbarWrapperInstaller : ServiceInstaller
{
    public override void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISnackbarWrapper, SnackbarWrapper>();
    }
}