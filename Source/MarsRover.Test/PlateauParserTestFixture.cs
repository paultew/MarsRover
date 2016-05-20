using System;
using MarsRover.Contracts;
using MarsRover.Entities;
using MarsRover.Parsers;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class PlateauParserTestFixture
    {
        private ISurfaceParser _surfaceParser;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _surfaceParser = new PlateauParser();
        }

        [TestCase(null)]
        [TestCase("")]
        public void Parse_CommandStringParameterIsNullOrEmpty_ThrowsArgumentNullException(string commandString)
        {
            Assert.Throws<ArgumentNullException>(() => _surfaceParser.Parse(commandString));
        }

        [TestCase(" ")]
        public void Parse_CommandStringParameterIsWhitespace_ThrowsInvalidDimensionsException(string commandString)
        {
            Assert.Throws<InvalidDimensionsException>(() => _surfaceParser.Parse(commandString));
        }

        [TestCase(" 100")]
        [TestCase("50 ")]
        [TestCase("50")]
        public void Parse_CommandStringParameterIsSingleDimension_ThrowsInvalidDimensionsException(string commandString)
        {
            Assert.Throws<InvalidDimensionsException>(() => _surfaceParser.Parse(commandString));
        }

        [TestCase("100 100 100")]
        [TestCase("50 50 50 50")]
        public void Parse_CommandStringParameterHasTooManyDimensions_ThrowsInvalidDimensionsException(string commandString)
        {
            Assert.Throws<InvalidDimensionsException>(() => _surfaceParser.Parse(commandString));
        }

        [TestCase("100 A")]
        [TestCase("A B")]
        public void Parse_CommandStringParameterNonNumericValues_ThrowsInvalidDimensionsException(string commandString)
        {
            Assert.Throws<InvalidDimensionsException>(() => _surfaceParser.Parse(commandString));
        }

        [TestCase("100 100")]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectType(string commandString)
        {
            Assert.That(_surfaceParser.Parse(commandString), Is.AssignableTo(typeof(Plateau)));
        }

        [TestCase("100 50", 100)]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectX(string commandString, int x)
        {
            var plateau = (Plateau) _surfaceParser.Parse(commandString);

            Assert.That(plateau.X, Is.EqualTo(x));
        }

        [TestCase("100 50", 50)]
        public void Parse_CommandStringParameterHasValidDimensions_ReturnsCorrectY(string commandString, int y)
        {
            var plateau = (Plateau)_surfaceParser.Parse(commandString);

            Assert.That(plateau.Y, Is.EqualTo(y));
        }
    }
}
