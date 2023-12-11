using System.Collections.Generic;
using System;

namespace Knapsack
{
    public class KnapsackGraph
    {
        public int MaxWeight { get; set; }
        public List<Item> Items { get; set; }
        private Dictionary<(int, int), int> values; // Stores only values, not items

        public KnapsackGraph(List<Item> items, int maxWeight)
        {
            Items = items;
            MaxWeight = maxWeight;
            values = new Dictionary<(int, int), int>();
            BuildGraph();
        }

        private void BuildGraph()
        {
            // Initialize the dictionary with an initial node (empty knapsack)
            values.Add((0, 0), 0);

            foreach (var item in Items)
            {
                var currentWeights = new List<(int, int)>(values.Keys);

                foreach (var (weight, value) in currentWeights)
                {
                    int newWeight = weight + item.Weight;
                    int newValue = value + item.Value;

                    if (newWeight <= MaxWeight)
                    {
                        if (!values.ContainsKey((newWeight, newValue)))
                        {
                            values.Add((newWeight, newValue), newValue);
                        }
                        else
                        {
                            values[(newWeight, newValue)] = Math.Max(values[(newWeight, newValue)], newValue);
                        }
                    }
                }
            }
        }

        public int GetMaxValue()
        {
            int maxValue = 0;

            foreach (var value in values.Values)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }

            return maxValue;
        }
    }
}