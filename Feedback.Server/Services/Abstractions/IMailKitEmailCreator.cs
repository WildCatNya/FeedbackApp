using Feedback.Server.Database.Entities;
using MimeKit;

namespace Feedback.Server.Services.Abstractions;

public interface IMailKitEmailCreator
{
    public MimeMessage CreateMessage(Subject subject);

    public MimeMessage CreateSupportMessage(string bodyText);
}