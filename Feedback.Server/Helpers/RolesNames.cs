namespace Feedback.Server.Helpers;

public static class RolesNames
{
    /// <summary>
    /// Создатель, тот кто может делать все
    /// </summary>
    public const string Creator = "Creator";

    /// <summary>
    /// Может делать многое, но не все
    /// </summary>
    public const string Admin = "Admin";

    /// <summary>
    /// Может видеть все, но не спрятанное
    /// </summary>
    public const string AllSeeing = "AllSeeing";

    /// <summary>
    /// Может отменять выполнение заявок
    /// </summary>
    public const string CanCancel = "CanCancel";

    /// <summary>
    /// Может прятать заявки
    /// </summary>
    public const string CanConceal = "CanConceal";

    /// <summary>
    /// Может удалять заявки
    /// </summary>
    public const string CanDelete = "CanDelete";
}