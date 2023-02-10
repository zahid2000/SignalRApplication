﻿using WebSocket.Hubs;

namespace WebSocket.Business;

public class MyBusiness
{
    private readonly IHubContext<MyHub> _hubContext;

    public MyBusiness(IHubContext<MyHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SenMessageAsync(string message)
    {
        await _hubContext.Clients.All.SendAsync("receiveMessage", message);
    }
}
