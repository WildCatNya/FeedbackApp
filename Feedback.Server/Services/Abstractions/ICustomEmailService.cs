using Feedback.Server.Database.Entities;

namespace Feedback.Server.Services.Abstractions;

public interface ICustomEmailService
{
    public void CreateAndSend(Subject subject, string? text = null);
}