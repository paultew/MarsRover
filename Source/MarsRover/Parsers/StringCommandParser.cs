using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using MarsRover.Commands;
using MarsRover.Contracts;

namespace MarsRover.Parsers
{
    public class StringCommandParser : ICommandParser
    {
        #region Implementation of ICommandParser

        public ICommand[] ParseCommands(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentNullException(nameof(command));

            var commandList = new List<ICommand>();
            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case 'L':
                        commandList.Add(new LeftCommand());
                        break;
                    case 'M':
                        commandList.Add(new MoveCommand());
                        break;
                    case 'R':
                        commandList.Add(new RightCommand());
                        break;
                    default:
                        throw new UnknownCommandException(command[i].ToString());
                }
            }

            return commandList.ToArray();
        }

        #endregion
    }
}
