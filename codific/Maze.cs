using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Codific.Interfaces;

namespace Codific
{
    public class Maze : IMaze
    {
        private IList<IRoom> allRooms;

        public IRoom FirstRoom { get; }

        public IRoom LastRoom { get; }

        public ReadOnlyCollection<IRoom> AllRooms
        {
            get => new ReadOnlyCollection<IRoom>(this.allRooms);
        }

        public Maze(IList<IRoom> allRooms, IRoom firstRoom, IRoom lastRoom)
        {
            this.allRooms = allRooms ?? throw new ArgumentNullException(nameof(allRooms));
            this.FirstRoom = firstRoom ?? throw new ArgumentNullException(nameof(firstRoom));
            this.LastRoom = lastRoom ?? throw new ArgumentNullException(nameof(lastRoom));
        }
    }
}
