using System.Collections.Concurrent;
using RealTimeApp.DataStreaming.Providers;
using RealTimeApp.Models;
using RealTimeApp.Services;
using RealTimeApp.SignalR;

namespace RealTimeApp.DataStreaming;

public class DataProviderFactory : IDataProviderFactory
{
    private readonly ConcurrentDictionary<MarketDataSources, IDataProvider> _providers = new();
    private readonly IPriceBroadcaster _priceBroadcaster;

    public DataProviderFactory(IPriceBroadcaster priceBroadcaster)
    {
        _priceBroadcaster = priceBroadcaster;
    }

    public IDataProvider GetDataProvider(ISymbol symbol)
    {
        return _providers.GetOrAdd(symbol.DataSource, (key) =>
        {
            return key switch
            {
                MarketDataSources.Stock => new StockDataProvider(_priceBroadcaster),
                MarketDataSources.Forex => new ForexDataProvider(_priceBroadcaster),
                _ => new DefaultDataProvider(_priceBroadcaster)
            };
        });
    }
}