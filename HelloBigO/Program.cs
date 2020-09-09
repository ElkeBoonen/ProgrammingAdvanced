using System;
using TM.ProgrammingAdvanced;

namespace HelloBigO
{
    class Program
    {
        public static int SimpleSearch(int[] numbers, int number, out int guesses)
        {
            int position = 0;
            guesses = 1;

            while (position < numbers.Length)
            {
                if (numbers[position] == number) return position;
                position++;
                guesses++;
            }
            return -1;
        }
        public static int StupidSearch(int[] numbers, int number, out int guesses)
        {
            Random rd = new Random();
            guesses = 0;
            do
            {
                int position = rd.Next(0, numbers.Length);
                guesses++;
                if (numbers[position] == number) return position;
            }
            while (guesses < (numbers.Length * 2));
            return -1;
        }
       
        public static int BinarySearch(int[] numbers, int number, out int guesses)
        {
            int min = 0;
            int max = numbers.Length;

            int position = (min + max) / 2;
            guesses = 1;

            while (min < max)
            {
                if (number == numbers[position])
                {
                    return position;
                }
                else if (number < numbers[position])
                {
                    max = position - 1;
                }
                else
                {
                    min = position + 1;
                }
                position = (min + max) / 2;
                guesses++;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] nrs = TM.ProgrammingAdvanced.Data.Numbers;

            Console.WriteLine("Enter number to find: ");
            string answer = Console.ReadLine();
            int nr;

            while (Int32.TryParse(answer, out nr))
            {
                int guesses;
                Console.WriteLine("Simple: " + SimpleSearch(nrs, nr, out guesses) + " (" + guesses + " guesses)");
                Console.WriteLine("Stupid: " + StupidSearch(nrs, nr, out guesses) + " (" + guesses + " guesses)");
                Console.WriteLine("Binary: " + BinarySearch(nrs, nr, out guesses) + " (" + guesses + " guesses)");
                
                Console.Write("Enter next number: ");
                answer = Console.ReadLine();
            }

        }
    }
}
