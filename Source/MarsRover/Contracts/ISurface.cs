namespace MarsRover.Contracts
{
    public interface ISurface
    {
        int X { get; }

        int Y { get; }

        bool IsValidLocation(ILocation location);
    }
}
