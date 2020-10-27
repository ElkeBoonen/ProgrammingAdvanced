using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DivideAndConquer
{
    class QuickSort
    {
        public int Count { get; set; }

        public void Print(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void Print(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public List<int> DCLists(List<int> list)
        {
            Count++;
            if (list.Count <= 1) return list;
            
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            int pivot = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] <= pivot) less.Add(list[i]);
                else greater.Add(list[i]);
            }
            return DCLists(less).Union(new List<int> { pivot }).Union(DCLists(greater)).ToList<int>();
        }

        public void DCArrays(int[] array, int low, int high)
        {
            Count++;
            if (low < high)
            {
                int pivot = Partition(array, low, high);
                DCArrays(array, low, pivot - 1);
                DCArrays(array, pivot+1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);
            int temp;

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i+1];
            array[i+1] = array[high];
            array[high] = temp;

            return (i + 1);
        }

    }
}
