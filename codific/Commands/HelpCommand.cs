using Codific.Interfaces.Engine;
using System;
using System.Linq;

namespace Codific.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly ICommandsRunner commandsRunner;
        private readonly IScreenDrawer screenDrawer;

        public HelpCommand(ICommandsRunner commandsRunner, IScreenDrawer screenDrawer)
        {
            this.commandsRunner = commandsRunner ?? throw new ArgumentNullException(nameof(commandsRunner));
            this.screenDrawer = screenDrawer ?? throw new ArgumentNullException(nameof(screenDrawer));
        }

        public string Description
        {
            get => "Показва всички команди на екрана";
        }

        public void Execute(string args)
        {
            var commandsNamesWithExplanations = commandsRunner.AllCommands.Select(c => "Команда \"" + c.Key + "\" - " + c.Value.Description);
            this.screenDrawer.ShowMessage(string.Join(Environment.NewLine, commandsNamesWithExplanations));
        }
    }
}
