using System;
using System.Collections.Generic;
using System.Text;

namespace HashTables
{
    class Book_Hash
    {
        private double[] book;

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


        public Book_Hash(int items)
        {
            int size = NextPrime((int)Math.Ceiling(items * 1.3));
            book = new double[size];
        }

        public int HashFunction(string item)
        {
            int h = 0;
            foreach(char c in item)
            {
                h += (int)c;
            }
            return h % book.Length;
        }

        private int HashFunctionHorner(string item)
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
            book[HashFunctionHorner(key)] = value;
        }

        public double GetPrice(string key)
        {
            return book[HashFunctionHorner(key)];
        }

        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < book.Length; i++)
            {
                s += book[i]+"\n";
            }
            return s;
        }
    }
}
