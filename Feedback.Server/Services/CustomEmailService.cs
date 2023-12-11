using Feedback.Server.Database.Entities;
using Feedback.Server.Services.Abstractions;
using MimeKit;

namespace Feedback.Server.Services;

public sealed class CustomEmailService : ICustomEmailService
{
    private readonly IMailKitEmailCreator _emailCreator;
    private readonly IMailKitEmailSender _emailSender;

    public CustomEmailService(IMailKitEmailCreator emailCreator, IMailKitEmailSender emailSender)
    {
        _emailCreator = emailCreator;
        _emailSender = emailSender;
    }

    public void CreateAndSend(Subject subject)
    {
        MimeMessage message = _emailCreator.CreateMessage(subject);

        try
        {
            _emailSender.Send(message);
        }
        catch (Exception ex)
        {
            MimeMessage supportMessage = _emailCreator.CreateSupportMessage(ex.Message);

            _emailSender.Send(supportMessage);
        }
    }
}
