using Feedback.Server.ServiceInstallers.Abstraction;
using MudBlazor;
using MudBlazor.Services;

namespace Feedback.Server.ServiceInstallers;

public sealed class MudInstaller : ServiceInstaller
{
    public override void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMudServices(options =>
        {
            options.SnackbarConfiguration.ClearAfterNavigation = true;
            options.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
            options.SnackbarConfiguration.PreventDuplicates = false;
        });
    }
}