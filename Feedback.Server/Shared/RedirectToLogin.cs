using Microsoft.AspNetCore.Components;

namespace Feedback.Server.Shared;

public sealed class RedirectToLogin : ComponentBase
{
    [Inject] private NavigationManager _navigationManager { get; set; }        

    protected override void OnAfterRender(bool firstRender) =>
        _navigationManager.NavigateTo("/account/login", true);
}