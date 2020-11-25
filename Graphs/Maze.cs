using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class Maze
    {
        public List<int>[] Nodes { get; set; }
        
        public Maze(int nrOfNodes)
        {
            Nodes = new List<int>[nrOfNodes];
            for (int i = 0; i < Nodes.Length; i++)
            {
                Nodes[i] = new List<int>();
            }
        }
        public void AddNode(int nr, int[] neighbors)
        {
            Nodes[nr].AddRange(neighbors);
        }

        public void AddEdge(int node, int next)
        {
            Nodes[node].Add(next);
            Nodes[next].Add(node);
        }
        

        private void DFS_Stack(int node)
        {
            bool[] visited = new bool[Nodes.Length];
            Stack<int> stack = new Stack<int>();

            visited[node] = true;
            stack.Push(node);

            while (stack.Count != 0)
            {
                node = stack.Pop();
                Console.WriteLine("next->" + node);

                if (node == 0) return;

                foreach (int next in Nodes[node])
                {
                    if (!visited[next])
                    {
                        visited[next] = true; 
                        stack.Push(next); 
                    }
                }
            }
        }


        private bool DFS_Recursion(int node, bool[] visited)
        {
            Console.WriteLine("next->" + node);

            if (node == 0) return true;

            foreach (int next in Nodes[node])
            {
                if (!visited[next])
                {
                    visited[next] = true;
                    return DFS_Recursion(next, visited);
                }
            }
            return false;
        }

        public void DFS(int node)
        {
            Console.WriteLine("\nStart node: " + node);
            Console.WriteLine("DFS - recursive method:");
            bool[] visited = new bool[Nodes.Length];
            visited[node] = true;
            DFS_Recursion(node, visited);

            Console.WriteLine("\nDFS - stack method:");
            DFS_Stack(node);
        }


        public void BFS(int node)
        {
            Console.WriteLine("\nStart node: " + node);
            Console.WriteLine("BFS:");

            bool[] visited = new bool[Nodes.Length];
            Queue<int> queue = new Queue<int>();

            visited[node] = true;
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                node = queue.Dequeue();
                Console.WriteLine("next->" + node);

                foreach (int next in Nodes[node])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        if (next == 0) return;
                        queue.Enqueue(next); 
                    }
                }
            }
        }

        public override string ToString()
        {
            string s = "PRINT MAZE\n";
            for (int i = 0; i < Nodes.Length; i++)
            {
                s += i + " --> ";
                foreach (var item in Nodes[i])
                {
                    s += item + " ";
                }
                s += "\n";
            }
            return s;
        }
    }
}
