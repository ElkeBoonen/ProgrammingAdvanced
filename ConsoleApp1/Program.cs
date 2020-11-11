using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a character");
            string answer = Console.ReadLine();
            Regex rx = new Regex(answer, RegexOptions.IgnoreCase);

            StreamReader reader = File.OpenText(@"Harry Potter and the Sorcerer.txt");
            string text = reader.ReadToEnd();
            reader.Close();
            MatchCollection matches = rx.Matches(text);
            Console.WriteLine(matches.Count + " matches found!");
            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }



        }
    }
}
