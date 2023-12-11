using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Knapsack
{

    class Knapsack
    {
        public List<Item> Items { get; set; }
        public int MaxWeight { get; set; }

        public Knapsack(List<Item> items, int maxweight)
        {
            Items = items;
            MaxWeight = maxweight;
        }

        public int Iterative()
        {
            int best_value = 0;

            for (int i = 0; i < (int)Math.Pow(2, Items.Count); i++)
            {
                string bin = Convert.ToString(i, 2).PadLeft(Items.Count, '0');

                int weight = 0;
                int value = 0;

                for (int j = 0; j < bin.Length; j++)
                {
                    if (bin[j] == '1')
                    {
                        weight += Items[j].Weight;
                        value += Items[j].Value;
                    }
                }

                if (weight <= MaxWeight)
                {
                    if (value > best_value)
                    {
                        best_value = value;
                    }
                }
            }

            return best_value;
        }

        public int Recursive(int capacity, int current)
        {
            if (capacity < 0)
            {
                return Int32.MinValue;
            }

            if (capacity == 0 || current >= Items.Count)
            {
                return 0;
            }

            int valueSelected = 0;

            if (capacity >= Items[current].Weight)
                valueSelected = Items[current].Value + Recursive(capacity - Items[current].Weight, current + 1);

            int valueNotSelected = Recursive(capacity, current + 1);
            return Math.Max(valueSelected, valueNotSelected);
        }

        public int Dynamic()
        {
            int[,] T = new int[Items.Count + 1, MaxWeight + 1];

            for (int i = 1; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    if (Items[i - 1].Weight > j)
                        T[i, j] = T[i - 1, j];
                    else
                    {

                        T[i,j] = Math.Max(T[i-1, j], T[i - 1, j-Items[i-1].Weight] + Items[i - 1].Value);
                    }

                }
            }
            return T[Items.Count,MaxWeight];
        }

        private void Print(int[,] T)
        {
            Console.WriteLine();
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    Console.Write(T[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int Greedy()
        {
            //just to keep the order of the orginal list!
            Item[] array = new Item[Items.Count];
            Items.CopyTo(array);

            Array.Sort(array);
            Array.Reverse(array);

            int weight = MaxWeight;
            int best_value = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Weight <= weight)
                {
                    weight -= array[i].Weight;
                    best_value += array[i].Value;
                }
            }
            return best_value;
        }

        


    }
}
