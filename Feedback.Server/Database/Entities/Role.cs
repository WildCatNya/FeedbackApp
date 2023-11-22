using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Role : Entity
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public List<Subject> Subjects { get; set; } = [];

    public List<UserAccountRole> UserAccountRoles { get; set; } = [];
}