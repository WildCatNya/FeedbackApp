using Feedback.Server.Database.Entities.Common;

namespace Feedback.Server.Database.Entities;

public sealed class Topic : Entity
{
    public string Value { get; set; } = null!;

    /// <summary>
    /// Цвет отображения в админке
    /// </summary>
    public string Color { get; set; } = null!;

    public List<Contact> Contacts { get; set; } = [];
}