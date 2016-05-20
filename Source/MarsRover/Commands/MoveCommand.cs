using MarsRover.Contracts;

namespace MarsRover.Commands
{
    public class MoveCommand : ICommand
    {
        #region Implementation of ICommand

        public CommandType CommandType
        {
            get { return CommandType.Move; }
        }

        public void Execute(IRover rover)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
