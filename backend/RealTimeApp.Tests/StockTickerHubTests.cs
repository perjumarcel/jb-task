using Microsoft.AspNetCore.SignalR;
using Moq;
using RealTimeApp.DataStreaming.Orchestrator;
using RealTimeApp.SignalR;

namespace RealTimeApp.Tests;

public class StockTickerHubTests
{
    private StockTickerHub? _hub;
    private Mock<IDataProviderOrchestrator>? _orchestrator;
    [SetUp]
    public void Setup()
    {
        _orchestrator = new Mock<IDataProviderOrchestrator>();
        _hub = new StockTickerHub(_orchestrator.Object)
        {
            Context = new Mock<HubCallerContext>().Object,
            Clients = new Mock<IHubCallerClients>().Object,
            Groups = new Mock<IGroupManager>().Object
        };
    }
    
    [Test]
    public void Subscribe_AddsSymbol()
    {
        _hub?.Subscribe("TSLA");
        _orchestrator?.Verify(o => o.AddSymbol("TSLA"), Times.Once);
    }
    
    [Test]
    public void Unsubscribe_RemovesSymbol()
    {
        _hub?.Unsubscribe("TSLA");
        _orchestrator?.Verify(o => o.RemoveSymbol("TSLA"), Times.Once);
    }
}