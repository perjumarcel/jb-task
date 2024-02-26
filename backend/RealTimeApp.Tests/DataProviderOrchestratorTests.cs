using Moq;
using RealTimeApp.DataStreaming;
using RealTimeApp.DataStreaming.Orchestrator;
using RealTimeApp.DataStreaming.Providers;
using RealTimeApp.Models;
using RealTimeApp.Services;

namespace RealTimeApp.Tests;

public class DataProviderOrchestratorTests
{
    private DataProviderOrchestrator? _orchestrator;
    private Mock<IDataProvider>? _dataProvider;
    
    [SetUp]
    public void Setup()
    {
        var symbolResolver = new SymbolResolver();
        _dataProvider = new Mock<IDataProvider>();
        _dataProvider.Setup(m => m.IsTrackingAny()).Returns(() => false);
        var dataProviderFactory = new Mock<IDataProviderFactory>();
        dataProviderFactory.Setup(m => m.GetDataProvider(It.IsAny<ISymbol>()))
            .Returns(_dataProvider.Object);
        
        _orchestrator = new DataProviderOrchestrator(symbolResolver, dataProviderFactory.Object);
    }
    [Test]
    public void AddSymbol_OnFirstTrackedSymbol_StartsDataProvider()
    {
        _orchestrator?.AddSymbol("AAPL");
        _dataProvider?.Verify(provider => provider.Start(), Times.Once);
    }
    
    [Test]
    public void RemoveSymbol_OnLastTrackedSymbol_StopsDataProvider()
    {
        _orchestrator?.RemoveSymbol("AAPL");
        _dataProvider?.Verify(provider => provider.Stop(), Times.Once);
    }
}