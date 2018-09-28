using Codific.Interfaces.Engine;
using System;

namespace Codific.Exceptions
{
    public class DublicateCommandException : Exception
    {
        public ICommand command { get; private set; }

        public DublicateCommandException(ICommand command)
        {
            this.command = command ?? throw new ArgumentNullException();
        }
    }
}
