using System;
using System.Collections.Generic;
using System.Text;

namespace HashTables
{
    class Book_KVP
    {
        private KeyValuePair<string, double>[] book;
        private int index = 0;

        public Book_KVP(int items)
        {
            book = new KeyValuePair<string, double>[items];
        }

        public void AddItem(string key, double value)
        {
            KeyValuePair<string, double> item = new KeyValuePair<string, double>( key, value );
            book[index] = item;
            index++;
        }

        public double GetPrice(string item)
        {
            Sort(book, 0, index-1);
            
            int min = 0;
            int max = index;

            int position = (min + max) / 2;

            while (min <= max)
            {
                if (item == book[position].Key)
                {
                    return book[position].Value;
                }
                else if (book[position].Key.CompareTo(item) > 0)
                {
                    max = position - 1;
                }
                else
                {
                    min = position + 1;
                }
                position = (min + max) / 2;
            }
            return -1;
        }

        private void Sort(KeyValuePair<string, double>[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);
                Sort(array, low, pivot - 1);
                Sort(array, pivot + 1, high);
            }
        }

        private int Partition(KeyValuePair<string, double>[] array, int low, int high)
        {
            string pivot = array[high].Key;
            int i = (low - 1);
            KeyValuePair<string,double> temp;

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j].Key.CompareTo(pivot) < 0)
                {
                    i++;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            return (i + 1);
        }

        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < index; i++)
            {
                s += book[i].Key + ": " + book[i].Value + "\n";
            }
            return s;
        }
    }
}
