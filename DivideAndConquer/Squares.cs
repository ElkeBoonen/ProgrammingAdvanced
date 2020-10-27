using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DivideAndConquer
{
    class Squares
    {
        public int Iterative(int A, int B)
        {
            for (int i = A; i > 0; i--)
            {
                if ((A%i==0) && (B%i==0))
                {
                    return i;
                }
            }
            return 1;
        }

        public int DivideAndConquer(int A, int B)
        {
            if (A == 0) return B;
            if (B == 0) return A;

            int remainder = A % B;
            return DivideAndConquer(B, remainder);
        }
    }
}
