using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DynamicProgramming
{
    class Subsequence
    {
        public string String1 { get; set; }
        public string String2 { get; set; }

        public void Recursive(string str, int index, string substring)
        {
            // base case 
            if (index == str.Length)
            {
                return;
            }
            //if (substring != null)
            //{
                Console.WriteLine(substring);
            //}
            for (int i = index + 1; i < str.Length; i++)
            {
                substring += str[i];
                Recursive(str, i, substring);

                // backtracking 
                substring = substring.Substring(0, substring.Length - 1);
            }
        }

       

        public void subsequence(string str)
        {
            int count = (int)Math.Pow(2, str.Length);
            for (int i = 0; i < count; i++)
            {
                string bin = Convert.ToString(i, 2).PadLeft(str.Length, '0'); ;
                Console.Write(bin + " ");
                string sub = "";
                for (int j = 0; j < bin.Length; j++)
                {
                    if (bin[j].Equals('1')) sub += str[j];
                }
                Console.WriteLine(sub);
            }
        }

        public string BruteForce()
        {
            
            return "";
        }
    }
}
