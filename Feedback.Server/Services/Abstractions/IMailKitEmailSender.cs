using Feedback.Server.Database.Entities;

namespace Feedback.Server.Services.Abstractions;

public interface IMailKitEmailSender
{
    public void Send(Subject subject);
}