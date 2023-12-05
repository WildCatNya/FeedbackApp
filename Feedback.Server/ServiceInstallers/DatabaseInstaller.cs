using Feedback.Server.Database;
using Feedback.Server.ServiceInstallers.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Server.ServiceInstallers;

public sealed class DatabaseInstaller : ServiceInstaller
{
    public override bool CanInstall => false;

    public override void Install(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(FeedbackContext.ConnectionStringName);

        services.AddDbContext<FeedbackContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}