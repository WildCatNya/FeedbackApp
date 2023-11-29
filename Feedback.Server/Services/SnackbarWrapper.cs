using Feedback.Server.Services.Abstractions;
using MudBlazor;

namespace Feedback.Server.Services;

public sealed class SnackbarWrapper : ISnackbarWrapper
{
    private readonly ISnackbar _snackbar;

    public SnackbarWrapper(ISnackbar snackbar)
    {
        _snackbar = snackbar;
    }

    public void SnackbarAdd(string message, Severity severity, string positionClass = "mud-snackbar-location-bottom-left")
    {
        _snackbar.Configuration.PositionClass = positionClass;
        _snackbar.Add(message, severity, configure: config => config.DuplicatesBehavior = SnackbarDuplicatesBehavior.Allow);
    }
}