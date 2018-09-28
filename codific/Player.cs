using Codific.EventArgs;
using Codific.Interfaces;
using System;
using System.Linq;

namespace Codific
{
    public class Player : IMainPlayer
    {
        public const int StartHealth = 100;

        public event EventHandler<RoomEventArgs> OnRoomEnter = delegate { };
        public event EventHandler<CreatureDeathEventArgs> OnCreatureDeath = delegate { };

        private int health;

        public int Health
        {
            get => this.health;
            set
            {
                this.health = Math.Max(0, value);

                if (this.health == 0)
                {
                    this.OnCreatureDeath(this, new CreatureDeathEventArgs(this));
                }
            }
        }

        public bool IsAlive
        {
            get => Health > 0;
        }

        public IRoom Position { get; set; }

        public IItemHolder Backpack { get; }

        public Player(IRoom firstRoom)
        {
            this.Health = StartHealth;
            this.Position = firstRoom ?? throw new ArgumentNullException();
            this.Backpack = new Backpack();
        }

        public void ReceiveDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!this.IsAlive)
            {
                throw new InvalidOperationException();
            }

            this.Health -= damage;
        }

        public void ChangePosition(IRoom room)
        {
            this.Position = room ?? throw new ArgumentNullException();
            this.OnRoomEnter(this, new RoomEventArgs(room));
        }

        public void ChangePosition(int roomNumber)
        {
            if (!this.Position.AllDoors.Select(d => d.Room.Number).Contains(roomNumber))
            {
                throw new InvalidOperationException($"Не може да отидеш до стая {roomNumber}. Няма врата от тази стая до нея");
            }

            var newPositionDoor = this.Position.AllDoors.First(d => d.Room.Number == roomNumber);

            if (newPositionDoor.RequiredItemForUnlocking != null && !this.Backpack.CurrentHoldingItems.Contains(newPositionDoor.RequiredItemForUnlocking))
            {
                throw new InvalidOperationException("Нямаш ключ за тази стая");
            }

            this.ChangePosition(newPositionDoor.Room);
        }
    }
}