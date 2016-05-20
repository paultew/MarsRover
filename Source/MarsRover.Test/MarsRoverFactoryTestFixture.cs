using System;
using System.Collections.Generic;
using MarsRover.Contracts;
using MarsRover.Entities;
using MarsRover.Factories;
using MarsRover.Parsers;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class MarsRoverFactoryTestFixture
    {
        private IRoverFactory _roverFactory;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _roverFactory = new MarsRoverFactory();
        }

        [TestCase(0, 0, Orientation.E)]
        [TestCase(50, 0, Orientation.W)]
        [TestCase(00, 50, Orientation.N)]
        [TestCase(66, 77, Orientation.S)]
        public void CreateRover_LocationParameterIsValid_LocationOrientationShouldBeSame(int x, int y, Orientation orientation)
        {
            var location = new TwoDimensionLocation(x, y, orientation);
            var surface = new Plateau(100, 100);

            var rover = _roverFactory.CreateRover(surface, location);
            Assert.That(rover.Location.Orientation, Is.EqualTo(orientation));
        }

        [TestCase(0, 0, Orientation.E)]
        [TestCase(50, 0, Orientation.E)]
        [TestCase(00, 50, Orientation.E)]
        [TestCase(66, 77, Orientation.E)]
        public void CreateRover_LocationParameterIsValid_LocationXShouldBeSame(int x, int y, Orientation orientation)
        {
            var location = new TwoDimensionLocation(x, y, orientation);
            var surface = new Plateau(100, 100);

            var rover = _roverFactory.CreateRover(surface, location);
            Assert.That(rover.Location.X, Is.EqualTo(x));
        }

        [TestCase(0, 0, Orientation.E)]
        [TestCase(50, 0, Orientation.E)]
        [TestCase(00, 50, Orientation.E)]
        [TestCase(66, 77, Orientation.E)]
        public void CreateRover_LocationParameterIsValid_LocationYShouldBeSame(int x, int y, Orientation orientation)
        {
            var location = new TwoDimensionLocation(x, y, orientation);
            var surface = new Plateau(100, 100);

            var rover = _roverFactory.CreateRover(surface, location);
            Assert.That(rover.Location.Y, Is.EqualTo(y));
        }

        // assert that the default location is not out of range (i.e. before any commands are issued)
        [TestCase(-10, 0, Orientation.E)]
        [TestCase(0, -10, Orientation.E)]
        [TestCase(50, 0, Orientation.E)]
        [TestCase(0, 50, Orientation.E)]
        [TestCase(66, 77, Orientation.E)]
        public void CreateRover_LocationParameterIsInvalid_ThrowsInvalidPositionException(int x, int y, Orientation orientation)
        {
            Mock<ILocation> location = new Mock<ILocation>();
            location.SetupProperty(l => l.X, x);
            location.SetupProperty(l => l.Y, y);
            location.SetupProperty(l => l.Orientation, orientation);

            var surface = new Plateau(40, 40);

            Assert.Throws<InvalidPositionException>(() => _roverFactory.CreateRover(surface, location.Object));
        }

        [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void MarsRoverExecute_StringBasedParameters_MatchesLocation(string surfaceDetails, string locationDetails, string commandList, string expectedLocation)
        {
            var surfaceParser = new PlateauParser();
            var locationParser = new TwoDimensionLocationParser();
            var commandParser = new StringCommandParser();

            var surface = surfaceParser.Parse(surfaceDetails);
            var location = locationParser.Parse(locationDetails);
            var commands = commandParser.ParseCommands(commandList);

            var rover = _roverFactory.CreateRover(surface, location);
            foreach (var command in commands)
            {
                rover.Execute(command);
            }

            Assert.That(rover.Location.LocationString, Is.EqualTo(expectedLocation));
        }

        [TestCase("5 5", "1 2 E", "MMRMMRMRRMMRRMRMRMMMMMMRMMMM")]
        public void MarsRoverExecute_StringBasedParametersMoveOutOfBoundary_ThrowsInvalidPositionException(string surfaceDetails, string locationDetails, string commandList)
        {
            var surfaceParser = new PlateauParser();
            var locationParser = new TwoDimensionLocationParser();
            var commandParser = new StringCommandParser();

            var surface = surfaceParser.Parse(surfaceDetails);
            var location = locationParser.Parse(locationDetails);
            var commands = commandParser.ParseCommands(commandList);

            var rover = _roverFactory.CreateRover(surface, location);

            Assert.Throws<InvalidPositionException>(() => ExecuteCommands(rover, commands));
        }

        private static void ExecuteCommands(IRover rover, IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                rover.Execute(command);
            }
        }
    }
}
