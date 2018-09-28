using System;
using System.Collections.Generic;

namespace Codific.Interfaces
{
    public interface IItemHolder
    {
        IReadOnlyCollection<IItem> CurrentHoldingItems { get; }

        int WeightCapacity { get; }

        int RemainingWeightCapacity { get; }

        bool CanPickupItem(IItem item);
        
        IItem DropItem(IItem item);
        
        void PickupItem(IItem item);
    }
}
