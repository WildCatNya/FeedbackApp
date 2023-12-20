using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class UserAccountEmail : Entity
{
    public int EmailId { get; set; }

    public int UserAccountId { get; set; }
}