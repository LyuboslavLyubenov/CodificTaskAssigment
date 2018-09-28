using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Codific.Exceptions;
using Codific.Interfaces;

namespace Codific
{
    public class Backpack : IItemHolder
    {
        private IList<IItem> items = new List<IItem>();

        public IReadOnlyCollection<IItem> CurrentHoldingItems
        {
            get => new ReadOnlyCollection<IItem>(this.items);
        }

        public int WeightCapacity
        {
            get => 80;
        }

        public int RemainingWeightCapacity
        {
            get => Math.Max(this.WeightCapacity - this.CurrentHoldingItems.Sum(i => i.Weight), 0);
        }

        public bool CanPickupItem(IItem item)
        {
            return item.Weight <= this.RemainingWeightCapacity;
        }

        public IItem DropItem(IItem item)
        {
            if (!this.items.Contains(item))
            {
                throw new NotFoundItemInBackpackException();
            }

            this.items.Remove(item);
            return item;
        }

        public void PickupItem(IItem item)
        {
            if (!this.CanPickupItem(item))
            {
                throw new NotEnoughWeightCapacityForItemException();
            }
            
            this.items.Add(item);
        }
    }
}
