using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTables
{
    class Book_HashSep
    {
        private List<KeyValuePair<string,double>>[] book;

        public Book_HashSep(int items)
        {
            int size = NextPrime((int)Math.Ceiling(items * 1.3));
            book = new List<KeyValuePair<string, double>>[size];
        }

        private bool isPrime(int n)
        {
            for (int i = 4; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private int NextPrime(int n)
        {
            while (!isPrime(n)) n++;
            return n;
        }

        private int HashFunction(string item)
        {
            long h = 0;
            foreach (char c in item)
            {
                h = (31 * h) + (int)c;
            }
            return (int)(h % book.Length);
        }

        public void AddItem(string key, double value)
        {
            int spot = HashFunction(key);
            if (book[spot]==null)
                book[spot] = new List<KeyValuePair<string, double>>();
            book[spot].Add(new KeyValuePair<string, double>(key, value));
        }

        public double GetPrice(string key)
        {
            int spot = HashFunction(key);
            foreach (var item in book[spot])
            {
                if (item.Key == key) return item.Value;
            }
            return -1;
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (var item in book)
            {
                if (item != null)
                {
                    foreach (var listitem in item)
                    {
                        s += " - " + listitem.Key + " " + listitem.Value;
                    }
                }
                else s += "null";
                s += "\n";
            }
            return s;
        }

    }
}
