using System;
using Codific.Interfaces.Engine;

namespace Codific
{
    public class ConsoleInputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
