using RealTimeApp.SignalR;

namespace RealTimeApp.DataStreaming.Providers;

public class ForexDataProvider : DefaultDataProvider
{
    public ForexDataProvider(IPriceBroadcaster priceBroadcaster) : base(priceBroadcaster)
    {
    }
}