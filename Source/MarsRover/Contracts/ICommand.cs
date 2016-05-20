namespace MarsRover.Contracts
{
    public interface ICommand
    {
        CommandType CommandType { get; }

        void Execute(IRover rover);
    }
}
