namespace RealTimeApp.DataStreaming.Orchestrator;

public interface IDataProviderOrchestrator
{
    void AddSymbol(string code);
    void RemoveSymbol(string code);
}