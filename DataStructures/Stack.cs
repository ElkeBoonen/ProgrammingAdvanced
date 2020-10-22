using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Stack
    {
        string[] elements;
        int top;

        public Stack(int size = 1000)
        {
            elements = new string[size];
            top = -1;
        }

        public bool IsEmpty()
        {
            return (top < 0);
        }

        public bool Push(string data)
        {
            if (top == elements.Length-1)
            {
                Console.WriteLine("Stack overflow");
                return false;
            }
            top++;
            elements[top] = data;
            return true;
        }

        public bool Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack underflow");
                return false;
            }
            top--;
            return true;
        }

        public override string ToString()
        {
            string print = "";
            if (top < 0) return "Stack underflow";

            for (int i = top; i >= 0; i--)
            {
                print += " | " + elements[i] ;
            }
            return print;
        }

    }
}
