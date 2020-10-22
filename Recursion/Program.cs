using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TM.ProgrammingAdvanced;

namespace Recursion
{
    class Program
    {
        static string Algorithm1(string path)
        {
            //making pile of boxes
            List<string> list = new List<string>();
            list.AddRange(Directory.GetDirectories(path));

            //as long as there are boxes
            while (list.Count > 0)
            {
                //take one and remove it from the pile
                string element = list[0];
                list.RemoveAt(0);
                Console.WriteLine(element);

                if (Directory.GetFiles(element).Length > 0) return element;
                else list.AddRange(Directory.GetDirectories(element));
            }
            return null;
        }

      
        static string Algorithm2(string path)
        {
            //loop through folder and check each element
            foreach (string element in Directory.GetFileSystemEntries(path))
            {
                Console.WriteLine(element);
                //if it is a folder
                if (Directory.Exists(element))
                {
                    //check if there is a folder inside
                    string result = Algorithm2(element);
                    if (result != null) return result; 
                    //only if there is a folder inside, go deeper!
                }
                //alse it is a file - whoop whoop, we are done!
                else return element;
            }
            //if box is empty return null, search in this box must stop!
            return null;
        }

        static int Factorial(int number)
        {
            int fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
                Console.WriteLine(i + ": - fact = " +fact);
            }
            return fact;
        }

        static int FactorialRecursive(int number)
        {
            Console.WriteLine("call with " + number);
            if (number > 1) 
                return (number * FactorialRecursive(number - 1));
            else return 1;
        }

        static void Main(string[] args)
        {
            string box = Data.Folders(@"C:\");

            Console.WriteLine("1 Found at " + Algorithm1(box) );
            Console.WriteLine("2 Found at " + Algorithm2(box) );

            Console.WriteLine("Factorial of 5 :" + Factorial(5));
            Console.WriteLine("Factorial of 5 :" + FactorialRecursive(5));

        }
    }
}
