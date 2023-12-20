using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Email : Entity
{
    public string Address { get; set; } = null!;

    public string Description { get; set; } = null!;

    public List<UserAccount> UserAccounts { get; set; } = [];
}