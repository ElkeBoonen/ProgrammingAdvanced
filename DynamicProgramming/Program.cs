using System;

namespace DynamicProgramming
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*Fibonacci f = new Fibonacci();
            Console.WriteLine(f.Iterative(40));
            Console.WriteLine(f.Recursive(40));
            */
            Cutting c = new Cutting(new int[] { 1,5,8,9 });

            Console.WriteLine("Highest profit: " + c.BruteForce(c.Length));
            Console.WriteLine("Highest profit: " + c.Memoization(c.Length));
            Console.WriteLine("Highest profit: " + c.Tabulation(c.Length));           
            
            /*choose your weapon :)*/
        }
    }
}
