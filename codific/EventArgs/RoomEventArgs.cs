using System;
using Codific.Interfaces;

namespace Codific.EventArgs
{
    public class RoomEventArgs : System.EventArgs
    {
        public IRoom Room { get; }

        public RoomEventArgs(IRoom room)
        {
            this.Room = room ?? throw new ArgumentNullException();
        }
    }
}
