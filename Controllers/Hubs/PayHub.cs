using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs;

public class PayHub : Hub
{
    public static readonly IDictionary<string, string> TransationConnections = new Dictionary<string, string>();
    public void RegisterTransaction(string id) 
    {
        var connectionId = Context.ConnectionId;
        TransationConnections[id] = connectionId;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        var item = TransationConnections.FirstOrDefault(p => p.Value == connectionId);
        TransationConnections.Remove(connectionId);
        return base.OnDisconnectedAsync(exception);
    }
}

