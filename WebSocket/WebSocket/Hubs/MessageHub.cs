namespace WebSocket.Hubs;

public class MessageHub : Hub
{
    //public async Task SendMessageAsync(string message,IEnumerable<string> connectionIds)
    //public async Task SendMessageAsync(string message, string groupName,IEnumerable<string> connectionIds)
    //public async Task SendMessageAsync(string message, IEnumerable<string> groups)

    public async Task SendMessageAsync(string message,string groupName)
    {
        #region Caller
        //Yalniz servere bildirim gonderen client-la iletisim qurar
        //await Clients.Caller.SendAsync("receiveMessage", message);
        #endregion
        #region Other
        //Sadece servere bildirim gonderen client xaricinde Servere bagli olan butun client-larla iletisim qurar
        //   await Clients.Others.SendAsync("receiveMessage", message);
        #endregion
        #region All
        // servere bagli olan butun client-larla iletisim qurar
        //await Clients.All.SendAsync("receiveMessage", message);
        #endregion

        #region Hub Clients Methods
        #region AllExcept
        //verilmis cconnectionId ler xaric servere bagli butun clientlara bildirim gonderir
        //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage",message);
        #endregion
        #region Client
        //verilmis connectionId - e bildirim gonderir
        //await Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage",message);
        #endregion
        #region Clients
        //verilmis connection idlere uygun clientlere mesaj gonderir
        //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
        #endregion
        #region Group
        //verilmis group adina gore groupdaki clientlara mesaj gonderir
        //await Clients.Group(groupName).SendAsync("receiveMessage",message);
        #endregion
        #region GroupExcept
        //verilen qrup daxilindeki verilmis connection idlere uygun gelen client-lar xaricindeki her kese mesaj gonderir
        //await Clients.GroupExcept(groupName,connectionIds).SendAsync("receiveMessage",message);
        #endregion
        #region Groups
        //verilmis gruplardaki butun client-lara mesaj gonderir
        //await Clients.Groups(groups).SendAsync("receiveMessage",message);
        #endregion
        #region OthersInGroup
        await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
        #endregion
        #endregion
    }
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
    }
    public async Task AddToGroup(string connectionId,string groupName)
    {
        await Groups.AddToGroupAsync(connectionId, groupName);
    }
}
