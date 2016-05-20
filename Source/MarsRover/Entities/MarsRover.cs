using System;
using MarsRover.Contracts;

namespace MarsRover.Entities
{
    public class MarsRover : IRover
    {
        private ILocation _location;
        private readonly ISurface _surface;

        public MarsRover(ILocation location, ISurface surface)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            if (surface == null) throw new ArgumentNullException(nameof(surface));

            _location = location;
            _surface = surface;

            if (!_surface.IsValidLocation(_location))
            {
                throw new InvalidPositionException(location.ToString());
            }
        }

        #region Implementation of IRover

        public ILocation Location { get { return _location; } }

        public void Execute(ICommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            switch (command.CommandType)
            {
                case CommandType.Move:
                    Move();
                    break;
                case CommandType.TurnLeft:
                    TurnLeft();
                    break;
                case CommandType.TurnRight:
                    TurnRight();
                    break;
                default:
                    throw new CommandNotSupportedException(string.Format("Command {0} not supported with type {1}", command.GetType().Name, command.CommandType.ToString("G")));
            }
        }

        #endregion

        private void Move()
        {
            var location = _location.Clone();

            if (location.Orientation == Orientation.N)
            {
                location.Y++;
            }
            else if (location.Orientation == Orientation.E)
            {
                location.X++;
            }
            else if (location.Orientation == Orientation.S)
            {
                location.Y--;
            }
            else if (location.Orientation == Orientation.W)
            {
                location.X--;
            }

            if (!_surface.IsValidLocation(location))
            {
                throw new InvalidPositionException(location.ToString());
            }

            // valid location so use that
            _location = location;
            System.Diagnostics.Debug.WriteLine("Move: " + _location.ToString());
        }

        private void TurnLeft()
        {
            switch (_location.Orientation)
            {
                case Orientation.E:
                    _location.Orientation = Orientation.N;
                    break;
                case Orientation.N:
                    _location.Orientation = Orientation.W;
                    break;
                case Orientation.S:
                    _location.Orientation = Orientation.E;
                    break;
                case Orientation.W:
                    _location.Orientation = Orientation.S;
                    break;
            }
            System.Diagnostics.Debug.WriteLine("TurnLeft: " +_location.ToString());
        }

        private void TurnRight()
        {
            switch (_location.Orientation)
            {
                case Orientation.E:
                    _location.Orientation = Orientation.S;
                    break;
                case Orientation.N:
                    _location.Orientation = Orientation.E;
                    break;
                case Orientation.S:
                    _location.Orientation = Orientation.W;
                    break;
                case Orientation.W:
                    _location.Orientation = Orientation.N;
                    break;
            }
            System.Diagnostics.Debug.WriteLine("TurnRight: " + _location.ToString());
        }
    }
}
