namespace WebSocket.Hubs;

public class MyHub : Hub
{
    public async Task SenMessageAsync(string message)
    {
     await  Clients.All.SendAsync("receiveMessage",message);
    }
}
