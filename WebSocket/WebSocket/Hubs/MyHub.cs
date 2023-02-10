using WebSocket.Hubs.Interfaces;

namespace WebSocket.Hubs;

public class MyHub : Hub<IMessageClient>
{
    static List<string> clients=new List<string>();
    public async Task SenMessageAsync(string message)
    {
        //await  Clients.All.SendAsync("receiveMessage",message);
        await Clients.All.ReceiveMessage(message);
    }

    public override async Task OnConnectedAsync()
    {
        clients.Add(Context.ConnectionId);
        //await Clients.All.SendAsync("clients", ClientList);
        //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        await Clients.All.Clients(clients);
        await Clients.All.UserJoined(Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {

        clients.Remove(Context.ConnectionId);
        //await Clients.All.SendAsync("clients", ClientList);
        //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        await Clients.All.Clients(clients);
        await Clients.All.UserLeaved(Context.ConnectionId);
    }
}
