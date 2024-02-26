using RealTimeApp.Models;

namespace RealTimeApp.Services;

public enum MarketDataSources
{
    Default,
    Forex,
    Stock
}

public interface ISymbolResolver
{
    ISymbol ResolveSymbol(string code);
}

public class SymbolResolver : ISymbolResolver
{
    private readonly HashSet<string> _forexCurrencies = new() { "USD", "EUR", "CHF" }; // just some example of currencies, a complete approach would be to retrieve these from a source (db, config, api)
    private readonly HashSet<string> _stockSymbols = new() { "AAPL", "TSLA", "AMZN" };
    
    public ISymbol ResolveSymbol(string code)
    {
        var marketDataSource = MarketDataSources.Default;
        if (_forexCurrencies.Contains(code.ToUpper()))
        {
            marketDataSource = MarketDataSources.Forex;
        }

        if (_stockSymbols.Contains(code.ToUpper()))
        {
            marketDataSource = MarketDataSources.Stock;
        }

        return new Symbol(code, marketDataSource);
    }
}