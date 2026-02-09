using Kanban.Services;
using Microsoft.AspNetCore.Components;

namespace Kanban.Components.Shared
{
    public abstract class UserStateAwareComponent : ComponentBase, IDisposable
    {
        [CascadingParameter] public UserState User { get; set; } = default!;

        protected override void OnInitialized()
        {
            User.OnChangeAsync += HandleUserChangeAsync;
        }

        protected virtual Task UserChanged() => Task.CompletedTask;

        private async Task HandleUserChangeAsync()
        {
            await UserChanged();
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            if (User is not null)
            {
                User.OnChangeAsync -= HandleUserChangeAsync;
            }
        }
    }
}

