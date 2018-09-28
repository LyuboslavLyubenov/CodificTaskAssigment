using System;
using System.Threading;
using Codific.Commands;
using Codific.EventArgs;
using Codific.Exceptions;
using Codific.Interfaces;
using Codific.Interfaces.Engine;
using Codific.Utils;

namespace Codific
{
    public class Engine : IEngine
    {
        private ICommandsRunner commandsRunner;
        private IInputReader inputReader;
        private IScreenDrawer screenDrawer;

        private bool isRunning = true;

        public Engine(ICommandsRunner commandsRunner, IInputReader inputReader, IScreenDrawer screenDrawer, IMainPlayer player, IRoom lastRoom)
        {
            this.commandsRunner = commandsRunner ?? throw new ArgumentNullException(nameof(commandsRunner));
            this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
            this.screenDrawer = screenDrawer ?? throw new ArgumentNullException(nameof(screenDrawer));

            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (lastRoom == null)
            {
                throw new ArgumentNullException(nameof(lastRoom));
            }

            player.OnRoomEnter += (sender, args) =>
            {
                player.Health -= 10;
                screenDrawer.ShowMessage($"Ти отиде до стая. Това ти костваше 10 живот. Имаш {player.Health} живот");
                
                if (args.Room.Number == lastRoom.Number)
                {
                    this.screenDrawer.ShowMessage("Край на играта.");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            };

            this.SetupCommands(player, commandsRunner, screenDrawer);
        }

        private void SetupCommands(IMainPlayer mainPlayer, ICommandsRunner commandsRunner, IScreenDrawer screenDrawer)
        {
            commandsRunner.AddCommand("помощ", new HelpCommand(commandsRunner, screenDrawer));
            commandsRunner.AddCommand("махни предмет", new DropItemCommand(mainPlayer, screenDrawer));
            commandsRunner.AddCommand("отиди до", new GoThroughCommand(mainPlayer, screenDrawer));
            commandsRunner.AddCommand("вземи предмет", new PickItemCommand(mainPlayer, screenDrawer));
            commandsRunner.AddCommand("покажи всички", new ShowItemsOnGroundCommand(mainPlayer, screenDrawer));
            commandsRunner.AddCommand("къде съм", new WhereAmICommand(mainPlayer, screenDrawer));
            commandsRunner.AddCommand("къде мога да отида", new WhereCanIGoCommand(mainPlayer, screenDrawer));
        }

        public void Run()
        {
            this.screenDrawer.ShowMessage("Добре дошъл в играта");
            this.screenDrawer.ShowMessage(
                "Трябва да стигнеш до последната стая. За да влезнеш в някои стаи ти трябва ключ");

            while (isRunning)
            {
                screenDrawer.ShowMessage("Въведи команда (напиши \"помощ\" за да видиш всички команди): ");
                var input = this.inputReader.ReadLine();

                try
                {
                    this.commandsRunner.RunCommand(input);
                }
                catch (NotFoundCommandException exception)
                {
                    ScreenDrawingUtils.DrawErrorMessage(this.screenDrawer,
                        "Не съществува такава команда. Може да видиш съществуващите команди като напишеш \"помощ\"");
                }
                catch (InvalidOperationException exception)
                {
                    ScreenDrawingUtils.DrawErrorMessage(this.screenDrawer, exception.Message);
                }
                catch (ArgumentException exception)
                {
                    ScreenDrawingUtils.DrawErrorMessage(this.screenDrawer, exception.Message);
                }
            }
        }
    }
}