using Feedback.Server.ServiceInstallers.Abstraction;
using Feedback.Server.Services;
using Feedback.Server.Services.Abstractions;
using MailKit.Net.Smtp;

namespace Feedback.Server.ServiceInstallers;

public sealed class EmailServicesInstaller : ServiceInstaller
{
    public override void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomEmailService, CustomEmailService>();

        services.AddScoped<IMailKitEmailCreator, MailKitEmailCreator>();

        services.AddScoped<IMailKitEmailSender, MailKitEmailSender>();

        services.AddSingleton<SmtpClient>();
    }
}