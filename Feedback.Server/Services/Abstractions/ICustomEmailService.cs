using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;

namespace Feedback.Server.Services.Abstractions;

public interface ICustomEmailService
{
    public void CreateAndSend(Subject subject, MailType mailType, string? text = null);
}