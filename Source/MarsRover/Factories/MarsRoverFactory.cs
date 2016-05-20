using MarsRover.Contracts;

namespace MarsRover.Factories
{
    public class MarsRoverFactory : IRoverFactory
    {
        #region Implementation of IRoverFactory

        public IRover CreateRover(ISurface surface, ILocation location)
        {
            return new Entities.MarsRover(location, surface);
        }

        #endregion
    }
}
