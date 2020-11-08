using System;
using System.Collections.Generic;
using System.Linq;
using TM.ProgrammingAdvanced;

namespace DivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            Squares squares = new Squares();
            Console.WriteLine(squares.Iterative(168, 64));
            Console.WriteLine(squares.DivideAndConquer(168, 64));

            Sum sum = new Sum();
            Console.WriteLine(sum.Iterative(new int[] { 2, 4, 6 }));
            Console.WriteLine(sum.DivideAndConquer(new List<int> { 2, 4, 6 }));

            Hanoi hanoi = new Hanoi();
            hanoi.DivideAndConquer(3, 'A', 'C', 'B');

            int[] array = Data.Numbers;
            List<int> list = array.ToList<int>();
            QuickSort qs = new QuickSort();
            qs.Count = 0;
            qs.Print(list);
            list = qs.DCLists(list);
            qs.Print(list);
            Console.WriteLine("Sorted in " + qs.Count + " operations");

            qs.Count = 0;
            qs.Print(array);
            qs.DCArrays(array, 0, array.Length-1);
            qs.Print(array);
            Console.WriteLine("Sorted in " + qs.Count + " operations");
        }
    }
}
