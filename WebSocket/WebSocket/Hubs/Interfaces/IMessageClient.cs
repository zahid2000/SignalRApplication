namespace WebSocket.Hubs.Interfaces;

public interface IMessageClient
{
    Task ReceiveMessage(string message);
    Task Clients(List<string> clients);
    Task UserJoined(string connectionId);
    Task UserLeaved(string connectionId);
}
