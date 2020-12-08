using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy
{
    class Maze
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


        public int GetNextNode(double[] priorities, bool[] visited)
        {
            double min = Int32.MaxValue;
            int next = -1;
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (!visited[i] && priorities[i] < min)
                {
                    min = priorities[i];
                    next = i;
                }
            }
            return next;
        }

        private double Heuristic(int current)
        {
            double h;
            int x = current % 5;
            int y = current / 5;
            h = Math.Abs(0 - x) + Math.Abs(0 - y);
            //h = Math.Sqrt((x * x) + y * y); euclidean distance
            return h;
        }

        public void AStar(int start)
        {
            int[] distances = new int[Nodes.Length];
            double[] priorities = new double[Nodes.Length];
            int[] pre = new int[Nodes.Length];
            bool[] visited = new bool[Nodes.Length];

            //every distance on max, visited is initialised at false
            for (int i = 0; i < Nodes.Length; i++)
            {
                distances[i] = Int32.MaxValue;
                priorities[i] = Int32.MaxValue;
                visited[i] = false;
                pre[i] = -1;
            }

            distances[start] = 0;
            priorities[start] = distances[start] + Heuristic(start);

            while (true)
            {
                int node = GetNextNode(priorities, visited);

                Console.WriteLine(node);
                if (node == -1 || node == 0) break;

                visited[node] = true;

                foreach (var item in Nodes[node])
                {
                    int distance = distances[node] + Math.Abs(node - item);

                    if (distance < distances[item])
                    {
                        pre[item] = node;
                        priorities[item] = distance + Heuristic(item);
                        distances[item] = distance;
                        visited[item] = false;
                    }
                }
            }

            int end = 0;
            string path = end.ToString();
            while (end != start)
            {
                end = pre[end];
                path = end + " " + path;
            }
            Console.WriteLine("\nShortest path A*: " + path);

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
