using Kanban.Services;
using Microsoft.AspNetCore.Components;

namespace Kanban.Components.Shared
{
    public abstract partial class StateAwareComponent : ComponentBase, IDisposable
    {
        [CascadingParameter] public KanbanState State { get; set; } = default!;

        protected override void OnInitialized()
        {
            State.OnChangeAsync += HandleStateChangeAsync;
        }

        private async Task HandleStateChangeAsync()
        {
            await StateChanged();
            await InvokeAsync(StateHasChanged);
        }

        protected virtual Task StateChanged() => Task.CompletedTask;

        public void Dispose()
        {
            if (State is not null)
            {
                State.OnChangeAsync -= HandleStateChangeAsync;
            }
        }
    }
}
