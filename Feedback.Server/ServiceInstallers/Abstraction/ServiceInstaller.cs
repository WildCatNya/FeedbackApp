namespace Feedback.Server.ServiceInstallers.Abstraction;

public abstract class ServiceInstaller
{
    public virtual bool CanInstall => true;

    public abstract void Install(IServiceCollection services, IConfiguration configuration);
}