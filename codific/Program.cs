using System;
using System.Text;
using Codific.Commands;
using Codific.Utils;

namespace Codific
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var commandsRunner = new CommandsRunner();
            var inputReader = new ConsoleInputReader();
            var screenDrawer = new ConsoleScreenDrawer();
            var maze = MazeGenerator.GeneratePreBuildMaze();
            var mainPlayer = new Player(maze.FirstRoom);
            
            new Engine(commandsRunner, inputReader, screenDrawer, mainPlayer, maze.LastRoom).Run();
        }
    }
}
