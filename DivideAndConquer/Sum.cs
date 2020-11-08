using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivideAndConquer
{
    class Sum
    {

        public int DivideAndConquer(List<int> list)
        {
            if (list.Count == 0) return 0;
            int first = list[0];
            list.RemoveAt(0);
            return first + DivideAndConquer(list);
        }


        public int Iterative(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }



    }
}
