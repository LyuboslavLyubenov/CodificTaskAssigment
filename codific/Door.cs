using System;
using Codific.Interfaces;

namespace Codific
{
    public class Door : IDoor
    {
        public IItem RequiredItemForUnlocking { get; }

        public IRoom Room { get; }

        public Door(IRoom room, IItem requiredItemForUnlocking)
        {
            this.Room = room ?? throw  new ArgumentNullException(nameof(room));
            this.RequiredItemForUnlocking = requiredItemForUnlocking;
        }

        public override bool Equals(object obj)
        {
            var otherDoor = obj as Door;

            if (otherDoor == null)
            {
                return false;
            }

            if (this.RequiredItemForUnlocking != otherDoor.RequiredItemForUnlocking || this.Room == otherDoor.Room)
            {
                return false;
            }

            return base.Equals(obj);
        }
    }
}
