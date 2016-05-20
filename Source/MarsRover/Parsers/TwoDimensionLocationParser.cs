using System;
using System.Linq;
using MarsRover.Contracts;
using MarsRover.Entities;

namespace MarsRover.Parsers
{
    public class TwoDimensionLocationParser : ILocationParser
    {
        private const int ArgumentCount = 3;
        private const char ValueSeparator = ' ';

        #region Implementation of ILocationParser

        public ILocation Parse(string details)
        {
            if (string.IsNullOrEmpty(details)) throw new ArgumentNullException(details);

            // keep any empty tokens so we know which dimension is junk should it not parse
            var tokens = details.Split(ValueSeparator);

            if (tokens.Length != ArgumentCount) throw new InvalidLocationException(string.Format("Dimensions has {0} arguments instead of {1}: {2}", tokens.Length, ArgumentCount, details));

            if (tokens.Any(string.IsNullOrEmpty)) throw new InvalidLocationException(string.Format("Dimensions have empty arguments: {0}", details));

            Orientation orientation = Orientation.N;
            int x = 0;
            int y = 0;
            for (int i = 0; i < ArgumentCount; i++)
            {
                switch (i)
                {
                    case 0:
                        ParseDimension(tokens, i, "X", ref x);
                        break;
                    case 1:
                        ParseDimension(tokens, i, "Y", ref y);
                        break;
                    case 2:
                        ParseOrientation(tokens, i, ref orientation);
                        break;
                }
            }

            return new TwoDimensionLocation { Orientation = orientation, X = x, Y = y};
        }

        #endregion

        private static void ParseDimension(string[] tokens, int index, string name, ref int dimension)
        {
            int val;
            if (!int.TryParse(tokens[index], out val))
            {
                throw new InvalidLocationException(string.Format("Dimension {0} is non-numeric: {1}", name, tokens[index]));
            }

            if (val == 0)
            {
                throw new InvalidLocationException(string.Format("Dimension {0} must be greater than zero: {1}", name, val));
            }

            dimension = val;
        }

        private static void ParseOrientation(string[] tokens, int index, ref Orientation orientation)
        {
            if (!Enum.TryParse<Orientation>(tokens[index], false, out orientation))
            {
                throw new InvalidLocationException(string.Format("{0} is an invalid orientation", tokens[index]));
            }
        }
    }
}
