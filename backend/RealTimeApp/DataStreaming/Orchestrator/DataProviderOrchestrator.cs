using RealTimeApp.Services;

namespace RealTimeApp.DataStreaming.Orchestrator;

public class DataProviderOrchestrator : IDataProviderOrchestrator
{
    private readonly ISymbolResolver _symbolResolver;
    private readonly IDataProviderFactory _dataProviderFactory;

    public DataProviderOrchestrator(ISymbolResolver symbolResolver, IDataProviderFactory dataProviderFactory)
    {
        _symbolResolver = symbolResolver;
        _dataProviderFactory = dataProviderFactory;
    }

    public void AddSymbol(string code)
    {
        var symbol = _symbolResolver.ResolveSymbol(code);
        var provider = _dataProviderFactory.GetDataProvider(symbol);
        if (!provider.IsTrackingAny())
        {
            provider.Start();
        }
        
        provider.TrackSymbol(symbol);
    }

    public void RemoveSymbol(string code)
    {
        var symbol = _symbolResolver.ResolveSymbol(code);
        var provider = _dataProviderFactory.GetDataProvider(symbol);
        provider.StopTrackingSymbol(symbol);

        if (!provider.IsTrackingAny())
        {
            provider.Stop();
        }
    }
}