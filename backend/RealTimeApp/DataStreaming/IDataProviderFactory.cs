using RealTimeApp.DataStreaming.Providers;
using RealTimeApp.Models;

namespace RealTimeApp.DataStreaming;

public interface IDataProviderFactory
{
    IDataProvider GetDataProvider(ISymbol symbol);
}