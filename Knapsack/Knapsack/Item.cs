using System;

namespace Knapsack
{
    public class Item : IComparable<Item>
    {
        public int Weight { get; set; }
        public int Value { get; set; }

        public Item(int value, int weight)
        {
            Weight = weight;
            Value = value;

        }
        public int CompareTo(Item other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
