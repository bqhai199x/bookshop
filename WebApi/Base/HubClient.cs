using Microsoft.AspNetCore.SignalR;

namespace WebApi.Base
{
    public interface IHubClient
    {
        Task ReceiveMessage(string message);
    }

    public class HubClient : Hub<IHubClient>
    {
        public override async Task OnConnectedAsync()
        {
            await AddToGroup(string.Empty);
            await BroadcastToConnection(Context.ConnectionId);
        }

        public async Task AddToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task RemoveFromGroup(string group)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }

        public async Task BroadcastToGroupAsync(string group, string message)
        {
            await Clients.Group(group).ReceiveMessage(message);
        }

        public async Task BroadcastToConnection(string message)
        {
            await Clients.Client(Context.ConnectionId).ReceiveMessage(message);
        }

        public async Task BroadcastToAll(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await RemoveFromGroup(string.Empty);
        }
    }
}
