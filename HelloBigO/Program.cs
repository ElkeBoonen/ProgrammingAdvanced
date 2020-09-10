using System;
using System.IO;
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
            while (guesses < (numbers.Length));
            return -1;
        }
       
        public static int BinarySearch(int[] numbers, int number, out int guesses)
        {
            int min = 0;
            int max = numbers.Length-1;

            int position = (min + max) / 2;
            guesses = 1;

            while (min <= max)
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


        public static void BigO(int[] nrs)
        {
            int guesses;

            /*range of numbers array is  [-999,999]
            so check every number in this range, let's see how many guesses
            every method needs to find the position of the number*/

            StreamWriter file = File.CreateText("guesses.txt");

            file.WriteLine("NUMBER;SIMPLE;GUESSES;STUPID;GUESSES;BINARY;GUESSES");
            for (int i = -999; i <= 999; i++)
            {
                file.Write(i + ";");
                file.Write(SimpleSearch(nrs, i, out guesses) + ";" + guesses + ";");
                file.Write(StupidSearch(nrs, i, out guesses) + ";" + guesses + ";");
                file.WriteLine(BinarySearch(nrs, i, out guesses) + ";" + guesses);
            }
            file.Close();

        }


        static void Main(string[] args)
        {
            int[] nrs = Data.Numbers;

            Console.Write("Enter number to find: ");
            string answer = Console.ReadLine();

            int number;
            while(Int32.TryParse(answer, out number))
            {
                int guesses;
                Console.WriteLine("Simple search - position at " + SimpleSearch(nrs, number, out guesses) + " (" + guesses + " guesses)");
                Console.WriteLine("Stupid search - position at " + StupidSearch(nrs, number, out guesses) + " (" + guesses + " guesses)");
                Console.WriteLine("Binary search - position at " + BinarySearch(nrs, number, out guesses) + " (" + guesses + " guesses)");

                Console.Write("\nNext number to find: ");
                answer = Console.ReadLine();
            }

        }
    }
}
