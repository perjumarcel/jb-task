using RealTimeApp.Helpers;
using RealTimeApp.SignalR;

namespace RealTimeApp.DataStreaming.Providers;

public class DefaultDataProvider : DataProvider
{
    public DefaultDataProvider(IPriceBroadcaster priceBroadcaster) : base(priceBroadcaster)
    {
    }
    
    protected override void UpdatePrices(object? state)
    {
        foreach (var kvp in SymbolsToTrack)
        {
            var newPrice = PriceHelper.GetPrice(kvp.Key);
            PriceBroadcaster.SendUpdate(kvp.Key, newPrice);
        }
    }
}