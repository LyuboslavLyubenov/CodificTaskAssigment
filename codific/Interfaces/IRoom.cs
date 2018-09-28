using System;
using System.Collections.Generic;

namespace Codific.Interfaces
{
    public interface IRoom
    {
        int Number { get; }

        IReadOnlyCollection<IDoor> AllDoors { get; }

        IReadOnlyCollection<IItem> ItemsInside { get; }

        void AddDoorTo(IRoom room, IItem key = null);
    }
}
