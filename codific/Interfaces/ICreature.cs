using System;
using Codific.EventArgs;

namespace Codific.Interfaces
{
    public interface ICreature
    {
        event EventHandler<CreatureDeathEventArgs> OnCreatureDeath;

        int Health { get; set; }
        
        bool IsAlive { get; }

        IRoom Position { get; }

        void ReceiveDamage(int damage);
    }
}