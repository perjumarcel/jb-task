using RealTimeApp.Services;

namespace RealTimeApp.Models;

public record Symbol(string Code, MarketDataSources DataSource) : ISymbol
{
    public string Code { get; set; } = Code;
    public MarketDataSources DataSource { get; set; } = DataSource;
}