using System;
using Codific.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Codific
{
    public class Room : IRoom
    {
        private static int NextRoomNumber = 1;

        private IList<IDoor> doors = new List<IDoor>();

        public Room(IList<IItem> items = null)
        {
            if (items == null)
            {
                var empty = new List<IItem>();
                this.ItemsInside = new ReadOnlyCollection<IItem>(empty);
            }
            else
            {
                this.ItemsInside = new ReadOnlyCollection<IItem>(items);
            }

            this.Number = NextRoomNumber++;
        }

        public int Number { get; }

        public IReadOnlyCollection<IDoor> AllDoors { get => new ReadOnlyCollection<IDoor>(this.doors); }

        public IReadOnlyCollection<IItem> ItemsInside { get; }

        public void AddDoorTo(IRoom room, IItem key = null)
        {
            if (room == null)
            {
                throw new ArgumentNullException();
            }

            var isThereTransitionToTheSameRoom = this.doors.ToList().Exists(d => d.Room == room);
            
            if (room == this || isThereTransitionToTheSameRoom)
            {
                throw new InvalidOperationException("Не може да добавиш врата до същата стая");
            }

            var door = new Door(room, key);
            this.doors.Add(door);
        }
    }
}
