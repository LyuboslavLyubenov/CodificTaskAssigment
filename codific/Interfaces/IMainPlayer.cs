using System;
using Codific.EventArgs;

namespace Codific.Interfaces
{
    public interface IMainPlayer : ICreature
    {
        event EventHandler<RoomEventArgs> OnRoomEnter;

        IItemHolder Backpack { get; }

        void ChangePosition(IRoom room);

        void ChangePosition(int roomNumber);
    }
}
