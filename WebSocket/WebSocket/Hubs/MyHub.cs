namespace WebSocket.Hubs;

public class MyHub : Hub
{
    static List<string> ClientList=new List<string>();
    public async Task SenMessageAsync(string message)
    {
     await  Clients.All.SendAsync("receiveMessage",message);
    }

    public override async Task OnConnectedAsync()
    {
        ClientList.Add(Context.ConnectionId);
        await Clients.All.SendAsync("clients", ClientList);
        await Clients.All.SendAsync("userJoined", Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {

        ClientList.Remove(Context.ConnectionId);
        await Clients.All.SendAsync("clients", ClientList);
        await Clients.All.SendAsync("userLeaved", Context.ConnectionId);

    }
}
