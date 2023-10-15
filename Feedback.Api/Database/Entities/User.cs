using Feedback.Api.Database.Entities.Common;

namespace Feedback.Api.Database.Entities;

public class User : Entity
{ 
    public string Login { get; set; }

    public string PasswordHash { get; set; }

    public string Role { get; set; }
}