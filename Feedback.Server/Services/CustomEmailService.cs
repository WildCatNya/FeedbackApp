using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;
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

    public void CreateAndSend(Subject subject, MailType mailType, string? text = null)
    {
        MimeMessage message = _emailCreator.CreateMessage(subject, text);

        try
        {
            _emailSender.Send(message);
        }
        catch (Exception ex)
        {
            MimeMessage supportMessage = _emailCreator.CreateSupportMessage($"{GetMailType(mailType)}\n{ex.Message}\nТема: {subject.ShortValue}");

            _emailSender.Send(supportMessage);
        }
    }

    private static string GetMailType(MailType mailType)
    {
        return mailType switch
        {
            MailType.Create => "Ошибка при создании заявки",
            MailType.Redirect => "Ошибка при перенаправлении заявки",
            MailType.Notify => "Ошибка при оповещении о незавершенных заявках",
            _ => "Неизвестная отправка почты"
        };
    }
}
