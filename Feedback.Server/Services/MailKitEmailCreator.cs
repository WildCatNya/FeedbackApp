using Feedback.Server.Database;
using Feedback.Server.Database.Entities;
using Feedback.Server.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Feedback.Server.Services;

public sealed class MailKitEmailCreator : IMailKitEmailCreator
{
    public const string ContactViewUrl = "http://lk.sibupk.su:6789/contacts/view";

    private readonly FeedbackContext _context;
    private readonly IConfiguration _configuration;
    private readonly string _emailName;

    public MailKitEmailCreator(FeedbackContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
        _emailName = _configuration["SMTP:EmailName"];
    }

    /// <summary>
    /// Создаёт сообщение по теме обращения
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="text">Если текст пустой, то будет использована стандартная фраза</param>
    /// <returns></returns>
    public MimeMessage CreateMessage(Subject subject, string? text)
    {
        MimeMessage message = new();

        message.From.Add(new MailboxAddress(_emailName, _configuration["SMTP:EmailAddress"]));

        var emails = Who(subject).ToList();

        foreach (var item in emails)
        {
            message.To.Add(new MailboxAddress(Guid.NewGuid().ToString(), item));
        }

        message.Subject = "Оповещение обратной связи: " + subject.ShortValue;

        message.Body = new TextPart("plain")
        {
            Text = text ?? "По вашей теме появилась новая заявка: " + ContactViewUrl
        };

        return message;
    }

    public MimeMessage CreateSupportMessage(string bodyText)
    {
        MimeMessage message = new();

        message.From.Add(new MailboxAddress(_emailName, _configuration["SMTP:EmailAddress"]));

        message.To.Add(new MailboxAddress(_emailName, _configuration["SMTP:SupportEmailAddress"]));

        message.Subject = "Оповещение обратной связи: Ошибка при отправлении";

        message.Body = new TextPart("plain")
        {
            Text = bodyText
        };

        return message;
    }

    private IEnumerable<string> Who(Subject subject)
    {
        List<UserAccountRole> uar = [.. _context.UserAccountRoles.Include(x => x.UserAccount).Include(x => x.Role)];

        return uar.Where(x => x.Role.Name == subject.Role.Name).Select(x => x.UserAccount.DepartmentEmail).Distinct();
    }
}
