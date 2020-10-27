using System;
using System.Collections.Generic;
using System.Text;

namespace DivideAndConquer
{
    class Hanoi
    {
        public void DivideAndConquer(int number, char from, char to, char other)
        {
            if (number == 1) Console.WriteLine("disk 1 from {0} to {1}", from, to);
            if (number > 1)
            {
                DivideAndConquer(number - 1, from, other, to); 
                Console.WriteLine("disk {0} from {1} to {2}", number, from, to);
                DivideAndConquer(number - 1, other, to, from); 
            }
        }
    }
}
