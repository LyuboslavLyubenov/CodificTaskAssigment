using System;
using Codific.Interfaces;

namespace Codific
{
    public class KeyItem : IItem
    {
        public string Name { get; }

        public int Weight { get; }

        public IDoor For { get; set; }

        public KeyItem(string name, int weight)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Name cant be empty", nameof(name));
            }

            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Name = name;
            this.Weight = weight;
        }

        public override bool Equals(object obj)
        {
            var otherKeyItem = obj as KeyItem;

            if (otherKeyItem == null)
            {
                return false;
            }

            if (this.Name != otherKeyItem.Name || this.Weight != otherKeyItem.Weight || this.For != otherKeyItem.For)
            {
                return false;
            }

            return base.Equals(obj);
        }
        
    }
}
