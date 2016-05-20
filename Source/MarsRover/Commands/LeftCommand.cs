using MarsRover.Contracts;

namespace MarsRover.Commands
{
    public class LeftCommand : ICommand
    {
        #region Implementation of ICommand

        public CommandType CommandType
        {
            get {  return CommandType.TurnLeft; }
        }

        public void Execute(IRover rover)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
