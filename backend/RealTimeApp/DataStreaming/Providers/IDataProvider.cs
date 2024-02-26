using RealTimeApp.Models;

namespace RealTimeApp.DataStreaming.Providers;

public interface IDataProvider
{
    void TrackSymbol(ISymbol symbol);
    void StopTrackingSymbol(ISymbol symbol);
    void Start();
    void Stop();
    bool IsTrackingAny();
}