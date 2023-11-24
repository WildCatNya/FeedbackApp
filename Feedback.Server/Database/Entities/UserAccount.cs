using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class UserAccount : Entity
{
    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string DepartmentEmail { get; set; } = null!;

    public List<LoginPermit> LoginPermits { get; set; } = [];

    public List<UserAccountRole> UserAccountRoles { get; set; } = [];
}