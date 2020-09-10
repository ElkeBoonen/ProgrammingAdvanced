using System;

namespace Recursion
{
    class Program
    {
        static int Factorial(int number)
        {
            int fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        static int FactorialRecursive(int number)
        {
            if (number > 1) 
                return (number * FactorialRecursive(number - 1));
            else return 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(10));
            Console.WriteLine(FactorialRecursive(10));
        }
    }
}
