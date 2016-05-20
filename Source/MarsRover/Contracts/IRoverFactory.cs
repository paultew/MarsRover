namespace MarsRover.Contracts
{
    public interface IRoverFactory
    {
        IRover CreateRover(ISurface surface, ILocation location);
    }
}
