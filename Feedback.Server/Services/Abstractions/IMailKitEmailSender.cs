using MimeKit;

namespace Feedback.Server.Services.Abstractions;

public interface IMailKitEmailSender
{
    public void Send(MimeMessage message);
}