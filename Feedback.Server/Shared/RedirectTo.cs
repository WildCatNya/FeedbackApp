using Microsoft.AspNetCore.Components;

namespace Feedback.Server.Shared;

public sealed class RedirectTo : ComponentBase
{
    [Parameter] public string? RedirectUrl { get; set; }

    [Inject] private NavigationManager _navigationManager { get; set; }        

    protected override void OnAfterRender(bool firstRender) =>
        _navigationManager.NavigateTo(RedirectUrl ?? "/", true);
}