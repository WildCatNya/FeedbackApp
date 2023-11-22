using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Role : Entity
{
    public string Name { get; set; } = null!;

    public List<UserAccountRole> UserAccountRoles { get; set; } = [];
}