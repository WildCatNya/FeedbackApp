namespace Feedback.Api.Database.Entities.Common;

public abstract class DictionaryEntity : Entity
{
    public string Value { get; set; } = null!;

    public bool Hide { get; set; }

    public List<ResultTable> Results { get; set; } = new();
}