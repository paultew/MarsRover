using System;
using MarsRover.Contracts;

namespace MarsRover.Entities
{
    public class TwoDimensionLocation : ILocation
    {
        public TwoDimensionLocation() { }

        public TwoDimensionLocation(int x, int y, Orientation orientation)
        {
            if (x < 0) throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0) throw new ArgumentOutOfRangeException(nameof(x));

            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
        }

        #region Implementation of ILocation

        public string LocationString
        {
            get { return string.Format("{0} {1} {2}", this.X, this.Y, this.Orientation.ToString("G")); }
        }

        public Orientation Orientation { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public ILocation Clone()
        {
            return (ILocation)this.MemberwiseClone();
        }

        #endregion

        #region Overrides of Object

        public override string ToString()
        {
            return string.Format("Location X:{0} Y:{1} Orientation:{2}", this.X, this.Y, this.Orientation.ToString("G"));
        }

        #endregion
    }
}
