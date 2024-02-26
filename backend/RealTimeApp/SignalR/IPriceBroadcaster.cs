namespace RealTimeApp.SignalR;

public interface IPriceBroadcaster
{
    Task SendUpdate(string symbol, decimal price);
}