namespace MarsRover.Contracts
{
    public interface ILocation
    {
        string LocationString { get; }

        Orientation Orientation { get; set; }

        int X { get; set; }

        int Y { get; set; }

        ILocation Clone();
    }
}
