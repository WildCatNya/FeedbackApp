using Feedback.Api.Database.Entities.Common;

namespace Feedback.Api.Database.Entities;

public class ResultTable : Entity
{
    public string Fio { get; set; }

    public int IdTopic { get; set; }

    public int IdSubject { get; set; }

    public string? Group { get; set; }

    public string Telephone { get; set; }

    public string Email { get; set; }

    public bool WhatsApp { get; set; }

    public string Text { get; set; }

    public bool Hide { get; set; }

    public Topic? IdTopicNavigation { get; set; }

    public Subject? IdSubjectNavigation { get; set; }
}