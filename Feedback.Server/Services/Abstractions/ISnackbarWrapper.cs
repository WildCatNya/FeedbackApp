using MudBlazor;

namespace Feedback.Server.Services.Abstractions;

public interface ISnackbarWrapper
{
    public void SnackbarAdd(string message, Severity severity, string positionClass = Defaults.Classes.Position.BottomLeft);
}