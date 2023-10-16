using Feedback.Api.Database.Entities.Common;

namespace Feedback.Api.Database.Entities;

public class UserToken : Entity
{
    public int IdUser { get; set; }

    public string RefreshToken { get; set; }

    public User? IdUserNavigation { get; set; }
}