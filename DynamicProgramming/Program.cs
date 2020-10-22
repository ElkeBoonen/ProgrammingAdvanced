using System;

namespace DynamicProgramming
{
    class Program
    {
        static int count = 0;
        static int[] mem;
        static int Fibonacci(int number)
        {
            if (number <= 1) return number;

            int fib1 = 0, fib2 = 1, fib3 = 1;

            for (int i = 2; i < number; ++i) 
            {
                //Console.WriteLine("fib: " + fib3);
                count++;
                fib1 = fib2;
                fib2 = fib3;
                fib3 = fib1 + fib2;
            }
            return fib3;
        }

        static int FibonacciRecursive(int number)
        {
            count++;
            //Console.Write("call with " + number + " ");
            if (number <= 1) return number;

            return FibonacciRecursive(number - 1) + FibonacciRecursive(number - 2);

        }

        static int FibonacciDPMem(int number)
        {
            if (number <= 1)
                return number;
            
            count++;
            if (mem[number] > 0)
                return mem[number];

            mem[number] = FibonacciDPMem(number - 1) + FibonacciDPMem(number - 2);
            return mem[number];
        }

        static int FibonacciDPTab(int number)
        {
            int[] tab = new int[number + 2];
            tab[0] = 0;
            tab[1] = 1;
            for (int i = 2; i < number; i++)
            {
                count++;
                tab[i] = tab[i - 1] + tab[i - 2];
            }
            return tab[number];
        }

        static void Hanoi(int number, char from, char to, char other)
        {
            if (number == 1) Console.WriteLine("Move disk 1 from {0} to {1}", from, to);
            if (number > 1)
            {
                Hanoi(number - 1, from, other,to);
                Console.WriteLine("Move disk {0} from {1} to {2}",number, from, to);
                Hanoi(number - 1, other, to, from);
            }

        }

    static void Main(string[] args)
        {
          /*choose your weapon :)*/
        }
    }
}
