using System;
using System.Collections.Generic;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> list = new List<Item>();
            //item value - weight
            list.Add(new Item(10,1));
            list.Add(new Item(5,2));
            list.Add(new Item(40,8));
            list.Add(new Item(45,10));


            Knapsack sack = new Knapsack(list, 10);

            Console.WriteLine($"Greedy: {sack.Greedy()}");
            Console.WriteLine($"Brute force: {sack.Iterative()}");
            Console.WriteLine($"Divide & conquer: {sack.Recursive(sack.MaxWeight, 0)}");
            Console.WriteLine($"Dynamic: {sack.Dynamic()}");

            KnapsackGraph graph = new KnapsackGraph(list, 10);
            Console.WriteLine($"Graph: {graph.GetMaxValue()}");

        }
    }
}
