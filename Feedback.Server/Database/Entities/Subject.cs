using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Subject : Entity
{
    public string Value { get; set; } = null!;

    public string DepartmentEmail { get; set; } = null!;

    public bool Hide { get; set; } = false;

    public List<Contact> Contacts { get; set; } = [];
}