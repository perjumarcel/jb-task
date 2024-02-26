using RealTimeApp.Services;

namespace RealTimeApp.Tests;

public class SymbolResolverTests
{
    private SymbolResolver _symbolResolver;
    [SetUp]
    public void Setup()
    {
        _symbolResolver = new SymbolResolver();
    }

    [Test]
    public void ResolveSymbol_WithStockSymbol_ReturnsStockDataSource()
    {
        var code = "AAPL";
        var result = _symbolResolver.ResolveSymbol(code);
        Assert.AreEqual(MarketDataSources.Stock, result.DataSource);
        Assert.AreEqual(code, result.Code);
    }
    
    [Test]
    public void ResolveSymbol_WithCurrencySymbol_ReturnsForexDataSource()
    {
        var code = "EUR";
        var result = _symbolResolver.ResolveSymbol(code);
        Assert.AreEqual(MarketDataSources.Forex, result.DataSource);
        Assert.AreEqual(code, result.Code);
    }   
    
    [Test]
    public void ResolveSymbol_WithStockSymbol_ReturnsDefaultDataSource()
    {
        var code = "EURUSD";
        var result = _symbolResolver.ResolveSymbol(code);
        Assert.AreEqual(MarketDataSources.Default, result.DataSource);
        Assert.AreEqual(code, result.Code);
    }
}