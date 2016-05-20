using System;
using System.Linq;
using MarsRover.Contracts;
using MarsRover.Entities;

namespace MarsRover.Parsers
{
    public class PlateauParser : ISurfaceParser
    {
        private const int ArgumentCount = 2;
        private const char ValueSeparator = ' ';

        #region Implementation of ISurfaceParser

        public ISurface Parse(string details)
        {
            if (string.IsNullOrEmpty(details)) throw new ArgumentNullException(details);

            // keep any empty dimensions so we know which dimension is junk should it not parse
            var dimensions = details.Split(ValueSeparator);

            if (dimensions.Length != ArgumentCount) throw new InvalidDimensionsException(string.Format("Dimensions has {0} arguments instead of {1}: {2}", dimensions.Length, ArgumentCount, details));

            if (dimensions.Any(string.IsNullOrEmpty)) throw new InvalidDimensionsException(string.Format("Dimensions have empty arguments: {0}", details));

            if (dimensions.Any(d => d == "0")) throw new InvalidDimensionsException(string.Format("Dimensions must be greater than zero: {0}", details));

            int x = 0;
            int y = 0;
            for (int i = 0; i < ArgumentCount; i++)
            {
                switch (i)
                {
                    case 0:
                        ParseDimension(dimensions, i, "X", ref x);
                        break;
                    case 1:
                        ParseDimension(dimensions, i, "Y", ref y);
                        break;
                }
            }

            return new Plateau(x, y);
        }

        #endregion

        private static void ParseDimension(string[] dimensions, int index, string name, ref int dimension)
        {
            int val;
            if (!int.TryParse(dimensions[index], out val))
            {
                throw new InvalidDimensionsException(string.Format("Dimension {0} is non-numeric: {1}", name, dimensions[index]));
            }

            if (val == 0)
            {
                throw new InvalidDimensionsException(string.Format("Dimension {0} must be greater than zero: {1}", name, val));
            }

            dimension = val;
        }
    }
}
