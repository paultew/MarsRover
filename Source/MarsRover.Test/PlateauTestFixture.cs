using System;
using MarsRover.Contracts;
using MarsRover.Entities;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class PlateauTestFixture
    {
        [TestCase(0, 0)]
        [TestCase(0, -10)]
        [TestCase(-10, 0)]
        [TestCase(-10, 10)]
        public void Constructor_AxisParameterLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Plateau(x, y));
        }

        [TestCase(50, 100)]
        [TestCase(100, 50)]
        public void Constructor_AxisParametersGreaterThanZero_DoesNotThrowException(int x, int y)
        {
            Assert.DoesNotThrow(() => new Plateau(x, y));
        }

        [TestCase(50, 0, Orientation.E)]
        [TestCase(100, 0, Orientation.E)]
        public void IsValidLocation_LocationHasPositiveXAxis_ReturnsValid(int x, int y, Orientation orientation)
        {
            Mock<ILocation> location = new Mock<ILocation>();

            location.SetupProperty(l => l.X, x);
            location.SetupProperty(l => l.Y, y);
            location.SetupProperty(l => l.Orientation, orientation);

            var surface = new Plateau(150, 150);

            Assert.That(surface.IsValidLocation(location.Object), Is.True);
        }

        [TestCase(0, 100, Orientation.E)]
        [TestCase(0, 50, Orientation.E)]
        public void IsValidLocation_LocationHasPositiveYAxis_ReturnsValid(int x, int y, Orientation orientation)
        {
            Mock<ILocation> location = new Mock<ILocation>();

            location.SetupProperty(l => l.X, x);
            location.SetupProperty(l => l.Y, y);
            location.SetupProperty(l => l.Orientation, orientation);

            var surface = new Plateau(150, 150);

            Assert.That(surface.IsValidLocation(location.Object), Is.True);
        }


        [TestCase(50, 100, 100, 100, Orientation.E)]
        [TestCase(100, 50, 100, 100, Orientation.E)]
        [TestCase(100, 100, 100, 100, Orientation.E)]
        public void IsValidLocation_LocationHasTopRightAxis_ReturnsValid(int x, int y, int surfaceX, int surfaceY, Orientation orientation)
        {
            Mock<ILocation> location = new Mock<ILocation>();

            location.SetupProperty(l => l.X, x);
            location.SetupProperty(l => l.Y, y);
            location.SetupProperty(l => l.Orientation, orientation);

            var surface = new Plateau(surfaceX, surfaceY);

            Assert.That(surface.IsValidLocation(location.Object), Is.True);
        }
    }
}
