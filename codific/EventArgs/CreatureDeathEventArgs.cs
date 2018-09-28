using Codific.Interfaces;

namespace Codific.EventArgs
{
    using System;

    public class CreatureDeathEventArgs : EventArgs
    {
        public ICreature Creature { get; private set; }

        public CreatureDeathEventArgs(ICreature creature)
        {
            this.Creature = creature;
        }
    }
}
