using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class UserAccountRole : Entity
{
    public int IdRole { get; set; }

    public int IdUserAccount { get; set; }

    public Role? Role { get; set; }

    public UserAccount? UserAccount { get; set; }
}