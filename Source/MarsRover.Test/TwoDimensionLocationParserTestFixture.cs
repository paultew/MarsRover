using System;
using MarsRover.Contracts;
using MarsRover.Entities;
using MarsRover.Parsers;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class TwoDimensionLocationParserTestFixture
    {
        private ILocationParser _locationParser;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _locationParser = new TwoDimensionLocationParser();
        }

        [TestCase(null)]
        [TestCase("")]
        public void Parse_CommandStringParameterIsNullOrEmpty_ThrowsArgumentNullException(string commandString)
        {
            Assert.Throws<ArgumentNullException>(() => _locationParser.Parse(commandString));
        }

        [TestCase(" ")]
        public void Parse_CommandStringParameterIsWhitespace_ThrowsInvalidLocationException(string commandString)
        {
            Assert.Throws<InvalidLocationException>(() => _locationParser.Parse(commandString));
        }

        [TestCase("100")]
        [TestCase("100 ")]
        [TestCase("100 50")]
        [TestCase("100 50 ")]
        public void Parse_CommandStringParameterHasTooFewParameters_ThrowsInvalidLocationException(string commandString)
        {
            Assert.Throws<InvalidLocationException>(() => _locationParser.Parse(commandString));
        }

        [TestCase("100 E 50")]
        [TestCase("100 50 Z")]
        public void Parse_CommandStringParameterHasTooInvalidParameters_ThrowsInvalidLocationException(string commandString)
        {
            Assert.Throws<InvalidLocationException>(() => _locationParser.Parse(commandString));
        }

        [TestCase("100 100 N")]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectType(string commandString)
        {
            Assert.That(_locationParser.Parse(commandString), Is.AssignableTo(typeof(TwoDimensionLocation)));
        }

        [TestCase("100 50 N", 100)]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectX(string commandString, int x)
        {
            var location = (TwoDimensionLocation)_locationParser.Parse(commandString);

            Assert.That(location.X, Is.EqualTo(x));
        }

        [TestCase("10 5 N", 5)]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectY(string commandString, int y)
        {
            var location = (TwoDimensionLocation)_locationParser.Parse(commandString);

            Assert.That(location.Y, Is.EqualTo(y));
        }

        [TestCase("100 50 N", Orientation.N)]
        [TestCase("100 50 E", Orientation.E)]
        [TestCase("100 50 S", Orientation.S)]
        [TestCase("100 50 W", Orientation.W)]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectOrientation(string commandString, Orientation orientation)
        {
            var location = (TwoDimensionLocation)_locationParser.Parse(commandString);

            Assert.That(location.Orientation, Is.EqualTo(orientation));
        }
    }
}
