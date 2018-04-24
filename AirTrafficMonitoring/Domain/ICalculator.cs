namespace AirTrafficMonitoring.Domain
{
    public interface ICalculator
    {
        double DetermineVelocity(ITrack track1, ITrack track2);
        double Direction(ITrack track1, ITrack track2);
    }
}