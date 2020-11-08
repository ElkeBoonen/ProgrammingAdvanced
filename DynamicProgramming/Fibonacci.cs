using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class Fibonacci
    {
        public int Operations { get; set; }
        private int[] _memoization;

        public int Iterative(int number)
        {
            if (number <= 1) return number;

            int fib1 = 0, fib2 = 1, fib3 = 1;

            for (int i = 2; i < number; ++i)
            {
                Operations++;

                fib1 = fib2;
                fib2 = fib3;
                fib3 = fib1 + fib2;
            }
            return fib3;
        }

        public int Recursive(int number)
        {
            //Operations++;
            //Console.Write("call with " + number + " ");
            if (number <= 1) return number;

            return Recursive(number - 1) + Recursive(number - 2);

        }

        public int Memoization(int number)
        {
            if (number <= 1)
                return number;

            Operations++;

            if (_memoization[number] > 0)
                return _memoization[number];

            _memoization[number] = Memoization(number - 1) + Memoization(number - 2);
            return _memoization[number];
        }

        public int Tabulation(int number)
        {
            int[] tab = new int[number + 2];
            tab[0] = 0;
            tab[1] = 1;
            for (int i = 2; i < number; i++)
            {
                Operations++;
                tab[i] = tab[i - 1] + tab[i - 2];
            }
            return tab[number];
        }
    }
}
