using Feedback.Server.Database;
using Feedback.Server.ServiceInstallers.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Server.ServiceInstallers;

public sealed class SqliteDatabaseInstaller : ServiceInstaller
{
    public override bool CanInstall => false;

    public override void Install(IServiceCollection services, IConfiguration configuration)
    {
        string dirPath = $@"{Directory.GetCurrentDirectory()}\wwwroot\Database";

        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);

        string connectionString = $@"Data Source = {dirPath}\Database.db";

        services.AddDbContext<FeedbackContext>(options =>
            options.UseSqlite(connectionString));
    }
}