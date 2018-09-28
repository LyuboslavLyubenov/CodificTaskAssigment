using System;

namespace Codific.Exceptions
{
    public class NotFoundCommandException : Exception
    {
        public string CommandArgs { get; }

        public NotFoundCommandException(string commandArgs)
        {
            this.CommandArgs = commandArgs ?? throw new ArgumentNullException();
        }
    }
}
