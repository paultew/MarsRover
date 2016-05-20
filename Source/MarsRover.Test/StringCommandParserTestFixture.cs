using System;
using MarsRover.Commands;
using MarsRover.Contracts;
using MarsRover.Parsers;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class StringCommandParserTestFixture
    {
        private ICommandParser _commandParser;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _commandParser = new StringCommandParser();
        }

        [TestCase(null)]
        [TestCase("")]
        public void ParseCommands_CommandStringParameterIsNullOrEmpty_ThrowsArgumentNullException(string commandString)
        {
            Assert.Throws<ArgumentNullException>(() => _commandParser.ParseCommands(commandString));
        }

        [TestCase("B")]
        [TestCase("MB")]
        public void ParseCommands_CommandStringParameterIsInvalid_ThrowsUnknownCommandException(string commandString)
        {
            Assert.Throws<UnknownCommandException>(() => _commandParser.ParseCommands(commandString));
        }

        [TestCase("M")]
        [TestCase("L")]
        [TestCase("R")]
        public void ParseCommands_CommandStringParameterIsSingleCommand_ArrayIsNotEmpty(string commandString)
        {
            Assert.That(_commandParser.ParseCommands(commandString), Is.Not.Null.And.Not.Empty);
        }

        [TestCase("M")]
        [TestCase("L")]
        [TestCase("R")]
        public void ParseCommands_CommandStringParameterIsSingleCommand_ArrayHasSingleCommand(string commandString)
        {
            Assert.That(_commandParser.ParseCommands(commandString).Length, Is.EqualTo(1));
        }

        [TestCase("L")]
        public void ParseCommands_CommandStringParameterIsLeftCommand_ReturnsLeftCommand(string commandString)
        {
            var parsedCommands = _commandParser.ParseCommands(commandString);

            Assert.That(parsedCommands[0], Is.AssignableTo(typeof(LeftCommand)));
        }

        [TestCase("M")]
        public void ParseCommands_CommandStringParameterIsMoveCommand_ReturnsMoveCommand(string commandString)
        {
            var parsedCommands = _commandParser.ParseCommands(commandString);

            Assert.That(parsedCommands[0], Is.AssignableTo(typeof(MoveCommand)));
        }

        [TestCase("R")]
        public void ParseCommands_CommandStringParameterIsRightCommand_ReturnsRightCommand(string commandString)
        {
            var parsedCommands = _commandParser.ParseCommands(commandString);

            Assert.That(parsedCommands[0], Is.AssignableTo(typeof(RightCommand)));
        }

        [TestCase("M")]
        [TestCase("L")]
        [TestCase("R")]
        public void ParseCommands_CommandStringParameterIsMultipleCommand_ArrayIsNotEmpty(string commandString)
        {
            Assert.That(_commandParser.ParseCommands(commandString), Is.Not.Null.And.Not.Empty);
        }

        [TestCase("LMLMLMLMM", 9)]
        [TestCase("MMRMMRMRRM", 10)]
        [TestCase("MRMLMRM", 7)]
        public void ParseCommands_CommandStringParameterIsMultipleCommand_ArrayHasCorrectCount(string commandString, int commandCount)
        {
            Assert.That(_commandParser.ParseCommands(commandString).Length, Is.EqualTo(commandCount));
        }

    }
}
