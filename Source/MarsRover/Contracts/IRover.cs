namespace MarsRover.Contracts
{
    public interface IRover
    {
        ILocation Location { get; }

        void Execute(ICommand command);
    }
}
