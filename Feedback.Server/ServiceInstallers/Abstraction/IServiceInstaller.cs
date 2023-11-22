namespace Feedback.Server.ServiceInstallers.Abstraction;

public interface IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration);
}