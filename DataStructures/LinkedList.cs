using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
    class LinkedList
    {
        public Node Head { get; set; }

        public LinkedList()
        {
            Head = null;
        }
        public void InsertFront(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = Head;
            Head = newNode;
        }

        public void InsertLast(int data)
        {
            Node newNode = new Node(data);
            if (Head == null) Head = newNode;
            else
            {
                Node last = GetLast();
                last.Next = newNode;
            }
        }

        public void InsertAfter(Node node, int data)
        {
            if (node == null)
            {
                Console.WriteLine("The previous node cannot be null!");
                return;
            }
            Node newNode = new Node(data);
            newNode.Next = node.Next;
            node.Next = newNode;
        }

        private Node GetLast()
        {
            Node temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public bool Delete(int data)
        {
            Node temp = Head;
            Node prev = null;
            
            if ((temp!=null) && (temp.Data == data))
            {
                Head = temp.Next;
                return true;
            }

            while ((temp.Next != null) && (temp.Data != data))
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null) return false;

            prev.Next = temp.Next;
            return true;
        }

        public bool Search(int data)
        {
            Node temp = Head;
            while (temp != null)
            {
                if (temp.Data == data) return true;
                temp = temp.Next;
            }
            return false;

        }

        public override string ToString()
        {
            string linkedlist = "";
            Node temp = Head;
            do
            {
                linkedlist += temp.Data + " -> ";
                temp = temp.Next;
            }
            while (temp != null);
            return linkedlist;
        }


    }
}
