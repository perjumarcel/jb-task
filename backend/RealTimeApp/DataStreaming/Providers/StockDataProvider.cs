using RealTimeApp.SignalR;

namespace RealTimeApp.DataStreaming.Providers;

public class StockDataProvider : DefaultDataProvider
{
    public StockDataProvider(IPriceBroadcaster priceBroadcaster) : base(priceBroadcaster)
    {
    }
}