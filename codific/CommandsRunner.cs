using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Codific.Exceptions;
using Codific.Interfaces.Engine;

namespace Codific
{
    public class CommandsRunner : ICommandsRunner
    {
        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        public IReadOnlyDictionary<string, ICommand> AllCommands { get => new ReadOnlyDictionary<string, ICommand>(this.commands); }

        public void AddCommand(string commandName, ICommand command)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentNullException(nameof(commandName));
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(commandName));
            }

            if (this.commands.ContainsKey(commandName))
            {
                throw new DublicateCommandException(command);
            }

            this.commands.Add(commandName, command);
        }

        public void RemoveCommand(string command)
        {
            if (!this.commands.ContainsKey(command))
            {
                throw new ArgumentException("Not found command " + command);
            }

            this.commands.Remove(command);
        }

        public void RunCommand(string commandNameAndArgs)
        {
            if (string.IsNullOrWhiteSpace(commandNameAndArgs))
            {
                throw new ArgumentNullException(commandNameAndArgs);
            }

            const string CommandNameAndArgsDelimiter = " - ";
            var commandNameAndArgsDelimiterIndex = commandNameAndArgs.IndexOf(CommandNameAndArgsDelimiter, StringComparison.Ordinal);

            if (commandNameAndArgsDelimiterIndex == -1)
            {
                commandNameAndArgsDelimiterIndex = commandNameAndArgs.Length;
            }

            var commandName = commandNameAndArgs.Substring(0, commandNameAndArgsDelimiterIndex);
            
            if (!this.commands.ContainsKey(commandName))
            {
                throw new NotFoundCommandException(commandNameAndArgs);
            }

            var commandArgs = commandName == commandNameAndArgs
                ? null
                : commandNameAndArgs.Substring(commandNameAndArgsDelimiterIndex + CommandNameAndArgsDelimiter.Length);

            this.commands[commandName].Execute(commandArgs);
        }
    }
}