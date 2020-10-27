using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace DynamicProgramming
{
    class Cutting
    {
        private int _length;
        private int[] _memoization;
        private int[] _prices;

        public int Length { get { return _length; } }
        public int[] Prices  {
            get { return _prices; }
            set { _prices = value;
                 _length = value.Length;
                _memoization = new int[_length + 1];
            } }

        public Cutting(int[] prices)
        {
            Prices = prices;
            _length = prices.Length;
            _memoization = new int[_length + 1];
        }

        public int BruteForce(int n)
        {
            if (n == 0) return 0; //base case
            int max = -1;
            for (int i = 1; i <= n ; i++)
            {
                max = Math.Max(max, Prices[i-1] + BruteForce(n - i));
            }
            return max;
        }

        public int Memoization(int n)
        {
            if (n == 0) return 0;
            if (_memoization[n] > 0) return _memoization[n];
            int max = -1;
            for (int i = 1; i <= n; i++)
            {
                max = Math.Max(max, Prices[i - 1] + Memoization(n - i));
                _memoization[n] = max;
            }
            return max;
        }

        public int Tabulation(int n)
        {
            Dictionary<int, string> cuts = new Dictionary<int, string>();
            int[] tabulation = new int[_length + 1];
            tabulation[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                int max = -1;
                for (int j = 1; j <= i; j++)
                {
                    max = Math.Max(max, Prices[j - 1] + tabulation[i - j]);
                    Console.Write(Prices[j - 1] + tabulation[i - j] + " ");
                    tabulation[i] = max;
                }
                Console.WriteLine();
            }
            return tabulation[n];
        }

    }
}
