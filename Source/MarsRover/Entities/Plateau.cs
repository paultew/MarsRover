using System;
using MarsRover.Contracts;

namespace MarsRover.Entities
{
    public class Plateau : ISurface
    {
        private readonly int _x;
        private readonly int _y;

        public Plateau(int x, int y)
        {
            if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x));
            if (y <= 0) throw new ArgumentOutOfRangeException(nameof(y));

            _x = x;
            _y = y;
        }

        public int X => _x;

        public int Y => _y;

        public bool IsValidLocation(ILocation location)
        {
            return location.X >= 0 && location.X <= this.X && location.Y >= 0 && location.Y <= this.Y;
        }
    }
}
