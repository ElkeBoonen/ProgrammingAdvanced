using System;
using TM.ProgrammingAdvanced;

namespace DataStructures
{
    class Program
    {
        
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertFront(5);
            Console.WriteLine(list.ToString());
            list.InsertFront(15);
            Console.WriteLine(list.ToString());
            list.InsertFront(55);
            Console.WriteLine(list.ToString());
            list.InsertLast(20);
            Console.WriteLine(list.ToString());
            list.Delete(15);
            Console.WriteLine(list.ToString());

            Console.WriteLine("Found 15? " + list.Search(15));
            Console.WriteLine("Found 20? " + list.Search(20));
            list.Delete(55);
            Console.WriteLine(list.ToString());
            list.Delete(20);
            Console.WriteLine(list.ToString());


            Stack stack = new Stack(5);
            Console.WriteLine(stack.ToString());
            stack.Push("this");
            Console.WriteLine(stack.ToString());
            stack.Push("is");
            Console.WriteLine(stack.ToString());
            stack.Push("a");
            Console.WriteLine(stack.ToString());
            stack.Push("stack");
            Console.WriteLine(stack.ToString());
            stack.Push("implementation");
            Console.WriteLine(stack.ToString());
            stack.Push("test");
            Console.WriteLine(stack.ToString());
            stack.Pop();
            Console.WriteLine(stack.ToString());
            stack.Pop();
            Console.WriteLine(stack.ToString());
            stack.Pop();
            Console.WriteLine(stack.ToString());
            stack.Pop();
            Console.WriteLine(stack.ToString());
            stack.Pop();
            Console.WriteLine(stack.ToString());
            stack.Pop();

        }
    }
}
