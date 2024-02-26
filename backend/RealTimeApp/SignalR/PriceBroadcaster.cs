using Microsoft.AspNetCore.SignalR;

namespace RealTimeApp.SignalR;


public class PriceBroadcaster:  IPriceBroadcaster
{
    private readonly IHubContext<StockTickerHub> _hubContext;

    public PriceBroadcaster(IHubContext<StockTickerHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task SendUpdate(string symbol, decimal price)
    {
        return _hubContext.Clients.Group(symbol).SendAsync("ReceiveUpdate", symbol, price);
    }
}