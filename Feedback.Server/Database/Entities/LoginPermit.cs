using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class LoginPermit : Entity
{
    public int IdUserAccount { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public UserAccount? UserAccount { get; set; }
}