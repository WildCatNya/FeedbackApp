using Feedback.Server.Database;
using Feedback.Server.Database.Entities;
using Feedback.Server.Services.Abstractions;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Feedback.Server.Services;

public sealed class MailKitEmailSender : IMailKitEmailSender
{
    private readonly FeedbackContext _context;
    private readonly IConfiguration _configuration;

    public MailKitEmailSender(FeedbackContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public void Send(Subject subject)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(_configuration["SMTP:EmailName"], _configuration["SMTP:EmailAddress"]));

        var emails = Who(subject).ToList();

        foreach (var item in emails)
        {
            message.To.Add(new MailboxAddress(Guid.NewGuid().ToString(), item));
        }

        message.Subject = "Обратная связь: " + subject.ShortValue;

        message.Body = new TextPart("plain")
        {
            Text = "По вашей теме появилась новая заявка"
        };

        using SmtpClient client = new();

        client.Connect(_configuration["SMTP:Address"], 465, true);

        client.Authenticate(_configuration["SMTP:Login"], _configuration["SMTP:Password"]);

        client.Send(message);

        client.Disconnect(true);
    }

    private IEnumerable<string> Who(Subject subject)
    {
        List<UserAccountRole> uar = [.. _context.UserAccountRoles.Include(x => x.UserAccount).Include(x => x.Role)];

        return uar.Where(x => x.Role.Name == subject.Role.Name).Select(x => x.UserAccount.DepartmentEmail).Distinct();
    }
}