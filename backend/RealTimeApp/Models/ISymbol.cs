using RealTimeApp.Services;

namespace RealTimeApp.Models;

public interface ISymbol
{
    string Code { get; set; }
    MarketDataSources DataSource { get; set; }
}