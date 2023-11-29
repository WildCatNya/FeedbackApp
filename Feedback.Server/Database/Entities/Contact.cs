using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Contact : Entity
{
    public int IdSubject { get; set; }

    public  int IdTopic { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? MiddleName { get; set; } = null!;

    public string FullName => $"{LastName} {Name} {MiddleName}";

    public string? StudentGroup { get; set; } = null!;

    public string? Telephone { get; set; } = null!;

    public bool HasWhatsApp { get; set; }

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreationTime { get; set; }

    public bool IsCompleted { get; set; } = false;

    public bool Hide { get; set; } = false;

    public Subject? Subject { get; set; }

    public Topic? Topic { get; set; }
}