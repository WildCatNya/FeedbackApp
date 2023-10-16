using Feedback.Api.Database.Entities.Common;
using Feedback.Shared;

namespace Feedback.Api;

public static class Extensions
{
    public static DictionaryRequest ToDictionaryRequest(this DictionaryEntity topic) =>
        new(topic.Value, topic.Hide);
}