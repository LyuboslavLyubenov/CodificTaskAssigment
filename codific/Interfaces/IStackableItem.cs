using System;
using System.Collections.Generic;

namespace Codific.Interfaces
{
    internal interface IStackableItem<T> where T : IItem
    {
        event EventHandler OnEmptyStack;

        int ItemCount { get; }

        void AddItems(int count = 1);

        IList<T> DropItems(int count = 1);
    }
}
