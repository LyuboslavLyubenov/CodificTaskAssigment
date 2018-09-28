using System;
using Codific.Interfaces.Engine;

namespace Codific
{
    public class ConsoleScreenDrawer : IScreenDrawer
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("");
        }
    }
}
