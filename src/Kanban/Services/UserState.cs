namespace Kanban.Services
{
    public class UserState
    {
        public string Role { get; set; } = "Visitor";

        public event Func<Task>? OnChangeAsync;

        public async Task SetRoleAsync(string role)
        {
            Role = role;
            await (OnChangeAsync?.Invoke() ?? Task.CompletedTask);
        }
    }
}
