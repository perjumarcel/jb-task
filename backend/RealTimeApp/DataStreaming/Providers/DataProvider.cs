using System.Collections.Concurrent;
using RealTimeApp.Models;
using RealTimeApp.SignalR;

namespace RealTimeApp.DataStreaming.Providers;

public abstract class DataProvider : IDataProvider
{
    protected readonly IPriceBroadcaster PriceBroadcaster;
    protected readonly ConcurrentDictionary<string, bool> SymbolsToTrack = new();
    private Timer? _updateTimer;

    protected DataProvider(IPriceBroadcaster priceBroadcaster)
    {
        PriceBroadcaster = priceBroadcaster;
    }

    protected abstract void UpdatePrices(object? state);
    public void TrackSymbol(ISymbol symbol)
    {
        SymbolsToTrack.TryAdd(symbol.Code, true);
    }

    public void StopTrackingSymbol(ISymbol symbol)
    {
        SymbolsToTrack.TryRemove(symbol.Code, out _);
    }

    public void Start()
    {
        _updateTimer = new Timer(UpdatePrices, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10));
    }

    public void Stop()
    {
        if (IsTrackingAny()) return;
        
        _updateTimer?.Change(Timeout.Infinite, 0);
        _updateTimer?.Dispose();
    }

    public bool IsTrackingAny()
    {
        return SymbolsToTrack.Any();
    }
}