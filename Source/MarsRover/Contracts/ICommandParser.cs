namespace MarsRover.Contracts
{
    public interface ICommandParser
    {
        ICommand[] ParseCommands(string command);
    }
}
