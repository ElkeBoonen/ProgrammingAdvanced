using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy
{
    class Scheduling
    {
        public double[] Start { get; set; }
        public double[] Finish { get; set; }
        public string[] Classes { get; set; }

        public Scheduling(string[] classes, double[] start, double[] end)
        {
            Start = start;
            Finish = end;
            Classes = classes;
        }

        public void Schedule()
        {
            int i, j;

            Console.Write("Following classes are selected: ");

            i = 0; //first class is always picked, because it is the first one to finish!
            Console.Write(Classes[i] + " ");

            for (j = 1; j < Classes.Length; j++)
            {
                if (Start[j] >= Finish[i])
                {
                    Console.Write(Classes[j] + " ");
                    i = j;
                }
            }
        }
    }
}
