namespace Feedback.Server.Helpers;

public class AuthHelper
{
    public string? Login { get; set; }

    public string? Password { get; set; }

    public void Clear() => (Login, Password) = (null, null);
}