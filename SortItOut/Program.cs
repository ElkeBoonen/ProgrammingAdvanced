using System;
using System.Collections.Generic;
using System.Linq;
using TM.ProgrammingAdvanced;


namespace SortItOut
{
    class Program
    {
        static int count;
        static int[] GetFirstSongs(int number)
        {
            int[] array = new int[number];
            for (int i = 0; i < number; i++)
            {
                int streams = Data.Songs.ElementAt(i).Value;
                array[i] = MapValue(streams);
            }
            return array;
        }
        public static int MapValue(int s,int a1=47265, int a2=155029, int b1=1, int b2=50)
        {
            return (int)(b1 + (((s-a1)*(b2-b1))/(a2-a1)));
        }

        static void Print(KeyValuePair<string, int>[] array)
        {
            foreach (KeyValuePair<string, int> pair in array)
            {
                Console.WriteLine(pair.Value + "\t" + pair.Key);
            }
        }
        static void Print(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        static void BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                //bubble up
                for (int j = 0; j < i ; j++)
                {
                    if (array[j] > array[j + 1]) //swap largest element
                    {
                        int b = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = b;
                    }
                }
            }
        }

        static void BubbleSort(KeyValuePair<string, int>[] array)
        {
            count = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    count++;
                    if (array[j].Value > array[j + 1].Value) 
                    {
                        KeyValuePair<string, int> b = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = b;
                    }
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int tmp = array[i]; //start in the beginning
                int j;

                for (j = i; j > 0; j--) //find the right insertion position
                {
                    if (array[j - 1] < tmp) //go over elements find the perfect spot
                        break;
                    //make some room: shift the sorted part to right
                    array[j] = array[j - 1];
                }
                //insert the current element
                array[j] = tmp;
            }
        }

        public static void InsertionSort(KeyValuePair<string, int>[] array)
        {
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                KeyValuePair<string, int> tmp = array[i];
                int j;

                for (j = i; j > 0; j--)
                {
                    count++;
                    if (array[j - 1].Value < tmp.Value) break;
                    array[j] = array[j - 1];
                }
                array[j] = tmp;
            }
        }

        public static void SelectionSort(KeyValuePair<string, int>[] array)
        {
            count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    count++;
                    if (array[j].Value < array[min].Value) min = j;
                }
                KeyValuePair<string, int> b = array[i];
                array[i] = array[min];
                array[min] = b;
            }
        }

        public static void SelectionSort(int[] array)
        {
            //loop over
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;   //take first as smallest
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min]) min = j; //find new smallest
                }
                int b = array[i]; //swap!!
                array[i] = array[min];
                array[min] = b;
            }
        }

        static void Main(string[] args)
        {
            int[] int_array = GetFirstSongs(10);
            BubbleSort(int_array);
            
            int_array = GetFirstSongs(10);
            SelectionSort(int_array);
            Print(int_array);

            int_array = GetFirstSongs(10);
            InsertionSort(int_array);
            
            KeyValuePair<string, int>[] songs_array = Data.Songs.ToArray();
            BubbleSort(songs_array);
            int b_count = count;
            Print(songs_array);

            songs_array = Data.Songs.ToArray();
            SelectionSort(songs_array);
            int s_count = count;
            Print(songs_array);

            songs_array = Data.Songs.ToArray();
            InsertionSort(songs_array);
            int i_count = count;
            Print(songs_array);

            Console.WriteLine(b_count + "\t" + s_count + "\t" + i_count);
        }
    }
}
