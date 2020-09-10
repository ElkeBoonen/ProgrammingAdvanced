using System;
using System.IO;
using TM.ProgrammingAdvanced;
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
            Data d = new Data();
            string folder = d.Folders(@"C:\");

            string[] folders = Directory.GetDirectories(folder);

            foreach (string s in folders)
            {
                Console.WriteLine(s);
                if (Directory.GetFiles(s).Length == 1)
                {
                    Console.WriteLine("found in " + s); 
                }
            }


            /*Console.WriteLine(Factorial(10));
            Console.WriteLine(FactorialRecursive(10));*/
        }
    }
}
