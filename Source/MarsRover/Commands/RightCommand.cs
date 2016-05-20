using MarsRover.Contracts;

namespace MarsRover.Commands
{
    public class RightCommand : ICommand
    {
        #region Implementation of ICommand

        public CommandType CommandType
        {
            get { return CommandType.TurnRight; }
        }

        public void Execute(IRover rover)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
