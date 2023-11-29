using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Subject : Entity
{
    public int IdRole { get; set; }

    public string Value { get; set; } = null!;

    public string ShortValue { get; set; } = null!;

    public bool Hide { get; set; } = false;

    public Role? Role { get; set; }

    public List<Contact> Contacts { get; set; } = [];
}