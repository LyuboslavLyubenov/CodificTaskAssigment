using System.Collections.Generic;

namespace Codific.Interfaces.Engine
{
    public interface ICommandsRunner
    {
        IReadOnlyDictionary<string, ICommand> AllCommands { get; }

        void AddCommand(string commandName, ICommand command);

        void RemoveCommand(string command); 
        
        void RunCommand(string commandNameAndArgs);
    }
}
