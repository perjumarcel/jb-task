using Microsoft.AspNetCore.SignalR;
using RealTimeApp.DataStreaming.Orchestrator;
using RealTimeApp.Helpers;

namespace RealTimeApp.SignalR;

public class StockTickerHub : Hub
{
    private readonly IDataProviderOrchestrator _orchestrator;

    public StockTickerHub(IDataProviderOrchestrator orchestrator)
    {
        _orchestrator = orchestrator;
    }

    public async Task Subscribe(string symbol)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, symbol);
        _orchestrator.AddSymbol(symbol);
    }

    public async Task Unsubscribe(string symbol)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, symbol);
        _orchestrator.RemoveSymbol(symbol);
    }
}